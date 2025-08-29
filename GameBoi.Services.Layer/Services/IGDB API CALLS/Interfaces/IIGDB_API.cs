using RestEase;

namespace GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces
{
    [Header("Accept", "application/json")]
    public interface IIGDB_API
    {
        [Post("/v4/games")]
        Task<string> GetGamesAsync(
            [Header("Client-ID")] string clientId,
            [Header("Authorization")] string authorization, 
            [Body] string requestBody);

        [Post("/v4/games")]
        Task<string> SearchGamesAsync(
            [Header("Client-ID")] string clientId,
            [Header("Authorization")] string authorization,
            [Body] string requestBody);
    }
}
