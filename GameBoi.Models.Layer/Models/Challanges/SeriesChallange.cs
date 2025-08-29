namespace GameBoi.Models.Layer.Models.Challanges
{
    public class SeriesChallange
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string SeriesName { get; set; }
        public List<SeriesChallangeEntry> Entries { get; set; }
    }

    public class SeriesChallangeEntry
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public bool isFinished { get; set; }
    }
}
