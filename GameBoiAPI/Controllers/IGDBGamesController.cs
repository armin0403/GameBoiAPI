using GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces;
using GameBoi.Services.Layer.Services.IGDB_Auth;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace GameBoiAPI.Controllers
{
    [Route("api/IGDBGameController")]
    [ApiController]
    public class IGDBGamesController : Controller
    {
        private readonly TwitchOAuthClient _twitchOAuthClient;
        private readonly IIGDB_GameService _igdbGameService;

        public IGDBGamesController(TwitchOAuthClient twitchOAuthClient,
        IIGDB_GameService iGDB_GameService)
        {
            _twitchOAuthClient = twitchOAuthClient;
            _igdbGameService = iGDB_GameService;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetAccessToken()
        {
            var token = await _twitchOAuthClient.GetClientCredentialTokenAsync();
            token.TokenAcquiredAt = DateTimeOffset.UtcNow;

            return Ok(token);
        }

        [HttpGet("popular-games")]
        public async Task<IActionResult> GetPopularGames()
        {
            var games = await _igdbGameService.GetPopularGamesAsync();
            return Ok(games);
        }

        [HttpGet("search-games")]
        public async Task<IActionResult> SearchGames(string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Ok(await _igdbGameService.GetPopularGamesAsync());
            }
            return Ok(await _igdbGameService.SearchGames(searchTerm));
        }
    }
}
