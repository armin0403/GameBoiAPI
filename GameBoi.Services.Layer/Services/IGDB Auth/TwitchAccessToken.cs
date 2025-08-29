namespace GameBoi.Services.Layer.Services.IGDB_Auth
{
    public class TwitchAccessToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public string[] Scope { get; set; }
        public string TokenType { get; set; }
        public DateTimeOffset TokenAcquiredAt { get; set; }
    
        public bool HasTokenExpired()
        {
            return (DateTimeOffset.UtcNow - TokenAcquiredAt).TotalSeconds > ExpiresIn;
        }
    }
}
