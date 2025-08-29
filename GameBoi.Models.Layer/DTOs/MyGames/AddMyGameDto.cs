namespace GameBoi.Models.Layer.DTOs.MyGames
{
    public class AddMyGameDto
    {
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

        ///wishlist or collection
        public string Status { get; set; }
    }

}
