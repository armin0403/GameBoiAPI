namespace GameBoi.Models.Layer.DTOs
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReTypePassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public string? Gamertag { get; set; }
        public string? FavPlatform { get; set; }
        public string? FavGenre { get; set; }
    }
}
