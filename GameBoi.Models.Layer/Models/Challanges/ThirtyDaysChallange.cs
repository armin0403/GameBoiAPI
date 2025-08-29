namespace GameBoi.Models.Layer.Models.Challanges
{
    public class ThirtyDaysChallange
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public List<ThirtyDayEntry> Entries { get; set; }
    }

    public class ThirtyDayEntry
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public string GameName { get; set; }
        public bool isFinished { get; set; }
    }
}
