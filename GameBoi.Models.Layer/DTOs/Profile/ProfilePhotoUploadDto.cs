using Microsoft.AspNetCore.Http;

namespace GameBoi.Models.Layer.DTOs.Profile
{
    public class ProfilePhotoUploadDto
    {
        public IFormFile File { get; set; }
        public string Username { get; set; }
    }
}
