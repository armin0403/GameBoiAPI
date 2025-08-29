using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;

namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public class TwitchOAuthClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly TwitchOAuthAPI _api;

        public TwitchOAuthClient(IOptions<TwitchAuthConfig> config)
        {
            _clientId = config.Value.ClientId;
            _clientSecret = config.Value.ClientSecret;

            _api = new RestClient("https://id.twitch.tv")
            {
                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                }
            }.For<TwitchOAuthAPI>();
        }

        public async Task<TwitchAccessToken> GetClientCredentialTokenAsync()
        {
            var formData = new Dictionary<string, string>()
            {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "grant_type", "client_credentials" }
            };

            return await _api.GetOAuth2Token(formData);
        }
    }
}
