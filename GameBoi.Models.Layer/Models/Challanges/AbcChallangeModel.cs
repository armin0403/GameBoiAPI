namespace GameBoi.Models.Layer.Models.Challanges
{
    public class AbcChallangeModel
    {
        public int id { get; set; }
        public User User { get; set; }
        public int userId {get; set;}
        public List<AbcEntry> Entries { get; set; }
    }

    public class AbcEntry
    {
        public int Id { get; set; }
        public char Letter { get; set; }
        public string GameName { get; set; }
        public bool isFinished { get; set; }
    }
}
