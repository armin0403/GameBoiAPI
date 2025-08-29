namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public interface ITokenStore
    {
        Task<TwitchAccessToken> GetTokenAsync();
        Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token);
    }
}
