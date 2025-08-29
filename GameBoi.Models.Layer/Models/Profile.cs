using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoi.Models.Layer.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId {get;set;}
        public User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string? Gamertag { get; set; }
        public string? FavPlatform { get; set; }
        public string? FavGenre { get; set; }

        public ICollection<MyGame>? MyGames { get; set; }
    }
}
