namespace GameBoi.Models.Layer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public string? Gamertag { get; set; }
        public string? FavPlatform { get; set; }
        public string? FavGenre { get; set; }

        public Profile Profile { get; set; }

    }
}

