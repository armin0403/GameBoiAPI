namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public class TokenManager
    {
        private readonly ITokenStore _tokenStore;
        private readonly TwitchOAuthClient _twitchOAuth;

        public TokenManager(ITokenStore tokenStore, TwitchOAuthClient twitchOAuth)
        {
            _tokenStore = tokenStore;
            _twitchOAuth = twitchOAuth;
        }

        public async Task<TwitchAccessToken> AcquireTokenAsync()
        {
            var currentToken = await _tokenStore.GetTokenAsync();
            if(currentToken?.HasTokenExpired() == false) 
            {
                return currentToken;
            }
            return await RefreshTokenAsync();
        }

        public async Task<TwitchAccessToken> RefreshTokenAsync()
        {
            var accessToken = await _twitchOAuth.GetClientCredentialTokenAsync();
            accessToken.TokenAcquiredAt = DateTimeOffset.UtcNow;
            var storedToken = await _tokenStore.StoreTokenAsync(accessToken);

            return storedToken;
        }
    }
}
