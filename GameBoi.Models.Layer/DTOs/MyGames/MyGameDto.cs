namespace GameBoi.Models.Layer.DTOs.MyGames
{
    public class MyGameDto
    {
        /// connecting fields
        public int Id { get; set; }
        public int UserId { get; set; }

        /// igdb mapped fields
        public int IGDB_id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }
        public string? ReleaseDate {get; set;}
        public string? Genres { get; set; }
        public string? Platform { get; set; }

        /// edited fields
        public string? Review { get; set; }
        public string? Rating { get; set; }
        public bool? Platinum { get; set; } = false;
        public int? TrophyCount { get; set; }

        public string Status { get; set; }
    }
}
