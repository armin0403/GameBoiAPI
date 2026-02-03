using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.DTOs.NewFolder;

namespace GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces
{
    public interface IIGDB_GameService
    {
        Task<List<IGDBGameDto>> GetPopularGamesAsync(int pageSize = 20, int pageNumber = 1);
        Task<List<IGDBGameDto>> SearchGames(string searchTerm, int pageSize = 20, int pageNumber = 1);
    }
}
