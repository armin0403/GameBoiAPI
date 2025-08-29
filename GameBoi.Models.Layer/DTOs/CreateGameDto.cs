namespace GameBoi.Models.Layer.DTOs
{
    public class CreateGameDto
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public int Rating { get; set; }
        public int TrophyCount { get; set; }
        public string Comment { get; set; }
    }
}
