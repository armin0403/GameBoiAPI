using GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces;
using GameBoi.Services.Layer.Services.IGDB_Auth;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GameBoi.Services.Layer.Services
{
    public class HelperServices
    {
        private readonly TokenManager _tokenManager;
        private readonly IIGDB_API _api;
        private readonly string _cliendId;

        public HelperServices(TokenManager tokenManager,
                              IIGDB_API iGDB_API,
                              IOptions<TwitchAuthConfig> config)
        {
            _tokenManager = tokenManager;
            _api = iGDB_API;
            _cliendId = config.Value.ClientId;
        }
        public async Task<Dictionary<int, string>> FetchIgdbNameAsync(string endpoint, List<int> ids, string fieldName)
        {
            if (ids == null || !ids.Any()) return new();

            var currentToken = await _tokenManager.AcquireTokenAsync();
            string accessToken = currentToken.AccessToken;

            string idsString = string.Join(",", ids.Distinct());
            var requestData = $"fields id, {fieldName}; where id = ({idsString});";

            var response = await GenericIGDBPostAsync(endpoint, requestData);

            var items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(response);

            return items.ToDictionary(
                item => Convert.ToInt32(item["id"]),
                item => item[fieldName]?.ToString() ?? "Unknown");
        }

        public async Task<string> GenericIGDBPostAsync (string endpoint, string query)
        {
            var token = await _tokenManager.AcquireTokenAsync();
            var accessToken = token.AccessToken;

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.igdb.com/v4/");
            client.DefaultRequestHeaders.Add("Client-ID", _cliendId);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            var content = new StringContent(query);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"IGDB API call failed: {errorContent}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
