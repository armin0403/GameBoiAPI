namespace GameBoi.Models.Layer.DTOs.Account
{
    public class ChangeEmailDto
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
        public string ConfirmNewEmail { get; set; }
    }
}
