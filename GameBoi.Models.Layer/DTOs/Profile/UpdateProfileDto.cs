namespace GameBoi.Models.Layer.DTOs.Profile
{
    public class UpdateProfileDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public string? Gamertag { get; set; }
        public string? FavPlatform { get; set; }
        public string? FavGenre { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
