namespace GameBoi.Models.Layer.DTOs
{
    public class ProfileDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Biography { get; set; } = "Please input biography";
    }
}
