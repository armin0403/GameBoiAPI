using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.DTOs.NewFolder;
using GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces;
using GameBoi.Services.Layer.Services.IGDB_Auth;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GameBoi.Services.Layer.Services.IGDB_API_CALLS
{
    public class IGDB_GameService : IIGDB_GameService
    {
        private readonly IIGDB_API _api;
        private readonly TokenManager _tokenManager;
        private readonly string _clientId;
        private readonly HelperServices _helperServices;
        private readonly IMapper _mapper;

        public IGDB_GameService(IIGDB_API api, IMapper mapper, TokenManager tokenManager, IOptions<TwitchAuthConfig> config, HelperServices helperServices)
        {
            _api = api;
            _tokenManager = tokenManager;
            _clientId = config.Value.ClientId;
            _helperServices = helperServices;
            _mapper = mapper;
        }
        public async Task<List<IGDBGameDto>> GetPopularGamesAsync(int pageSize = 20, int pageNumber = 1)
        {
            var currentToken = await _tokenManager.AcquireTokenAsync();
            string accessToken = currentToken.AccessToken;

            var requestData = $@"
            fields id, name, first_release_date, cover.url, genres, platforms;
            sort popularity desc;
            limit {pageSize};
            offset {(pageNumber - 1)*pageSize};";

            var response = await _api.GetGamesAsync(_clientId, $"bearer {accessToken}", requestData);
            var games = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IGDBGameDto>>(response);

            var genreIds = games.SelectMany(g => g.Genres ?? new List<int>()).Distinct().ToList();
            var platformsIds = games.SelectMany(g => g.Platforms ?? new List<int>()).Distinct().ToList();

            var genreNames = await _helperServices.FetchIgdbNameAsync("genres", genreIds, "name");
            var platformsNames = await _helperServices.FetchIgdbNameAsync("platforms", platformsIds, "name");

            foreach(var game in games)
            {
                game.GenreNames = game.Genres?.Select(id => genreNames.GetValueOrDefault(id)).ToList();
                game.PlatformNames = game.Platforms?.Select(id => platformsNames.GetValueOrDefault(id)).ToList();
            }

            return games;
        }

        public async Task<List<IGDBGameDto>> SearchGames(string searchTerm, int pageSize = 20, int pageNumber = 1)
        {
            var currentToken = await _tokenManager.AcquireTokenAsync();
            string accessToken = currentToken.AccessToken;

            var requestData = $@"
            fields id, name, 
            first_release_date, 
            cover.url, genres, 
            platforms; 
            search ""{searchTerm}"";
            where version_parent = null;
            offset {(pageNumber - 1)*pageSize};
            limit {pageSize};";

            var response = await _api.SearchGamesAsync(_clientId, $"bearer {accessToken}", requestData);

            var games = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IGDBGameDto>>(response);

            var genreIds = games.SelectMany(g => g.Genres ?? new List<int>()).Distinct().ToList();
            var platformsIds = games.SelectMany(g => g.Platforms ?? new List<int>()).Distinct().ToList();

            var genreNames = await _helperServices.FetchIgdbNameAsync("genres", genreIds, "name");
            var platformsNames = await _helperServices.FetchIgdbNameAsync("platforms", platformsIds, "name");

            foreach (var game in games)
            {
                game.GenreNames = game.Genres?.Select(id => genreNames.GetValueOrDefault(id, "Unknown")).ToList();
                game.PlatformNames = game.Platforms?.Select(id => platformsNames.GetValueOrDefault(id, "Unknown")).ToList();
            }

            return games;
        }
    }
}
