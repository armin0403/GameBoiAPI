
namespace GameBoi.Models.Layer.Models
{
    public class MyGame
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        /// igdb mapped fields
        public int IGDB_id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genres { get; set; }
        public string Platform { get; set; }

        /// edited fields
        public string? Review { get; set; }
        public float? Rating { get; set; }
        public bool? Platinum { get; set; } = false;
        public int? TrophyCount { get; set; }

        public string Status { get; set; }

    }
}
