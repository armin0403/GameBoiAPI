namespace GameBoi.Models.Layer.DTOs.Games
{
    public class UpdateGameDto
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int TrophyCount { get; set; }
        public bool Platinum { get; set; } = false;
    }
}
