using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.DTOs.NewFolder;

namespace GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces
{
    public interface IIGDB_GameService
    {
        Task<List<MyGameDto>> GetPopularGamesAsync();
        Task<List<MyGameDto>> SearchGames(string searchTerm);
    }
}
