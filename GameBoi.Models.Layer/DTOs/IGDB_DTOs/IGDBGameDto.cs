namespace GameBoi.Models.Layer.DTOs.NewFolder
{
    public class IGDBGameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public long? First_Release_Date { get; set; }
        public double? Total_rating { get; set; }
        public Cover? Cover { get; set; }
        
        public List<int> Genres { get; set; }
        public int? GameType { get; set; }
        public List<int> Platforms { get; set; }

        public List<string> GenreNames { get; set; }
        public List<string> PlatformNames { get; set; }
        public string GameTypeName { get; set; }

    }

    public class Cover
    {
        public string? Url { get; set; }
    }
}
