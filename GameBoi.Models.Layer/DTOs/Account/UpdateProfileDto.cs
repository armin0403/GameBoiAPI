namespace GameBoi.Models.Layer.DTOs.Account
{
    public class UpdateProfileDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public string? Biography { get; set; }
        public string? Gamertag { get; set; }
        public string? FavPlatform { get; set; }
        public string? FavGenre { get; set; }
    }
}
