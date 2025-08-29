namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public sealed class TokenStore : ITokenStore
    {
        private static TwitchAccessToken CurrentToken { get; set; }

        public Task<TwitchAccessToken> GetTokenAsync()
        {
            return Task.FromResult(CurrentToken);
        }

        public Task<TwitchAccessToken> StoreTokenAsync(TwitchAccessToken token)
        {
            CurrentToken = token;
            return Task.FromResult(token);
        }
    }
}
