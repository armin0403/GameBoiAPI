namespace GameBoi.Models.Layer.DTOs.NewFolder
{
    public class IGDBGameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url => Cover?.Url == null ? null : "https:" + Cover.Url.Replace("t_thumb", "t_cover_big");
        public long? First_Release_Date { get; set; }
        public Cover? Cover { get; set; }
        
        public List<int> Genres { get; set; }
        public List<int> Platforms { get; set; }

        public List<string>? GenreNames { get; set; }
        public List<string>? PlatformNames { get; set; }

        public string ReleaseDate =>
        First_Release_Date.HasValue
            ? DateTimeOffset.FromUnixTimeSeconds(First_Release_Date.Value).DateTime.ToString("dd.MM.yyyy")
            : "Unknown";

        public string GenreDisplay => (GenreNames != null && GenreNames.Any(g => !string.IsNullOrEmpty(g))) ? string.Join(", ", GenreNames.Where(g => !string.IsNullOrEmpty(g))) : "Unknown";
        public string PlatformDisplay => (PlatformNames != null && PlatformNames.Any(p => !string.IsNullOrEmpty(p))) ? string.Join(", ", PlatformNames.Where(p => !string.IsNullOrEmpty(p))) : "Unknown";
    }

    public class Cover
    {
        public string? Url { get; set; }
    }
}
