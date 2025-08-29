using RestEase;

namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public interface TwitchOAuthAPI
    {
        [Post("/oauth2/token")]
        Task<TwitchAccessToken> GetOAuth2Token([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> data);
    }
}
