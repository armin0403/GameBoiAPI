using Microsoft.AspNetCore.Http;

namespace GameBoiAPI.Helpers.FileHandler
{
    public class FileHandler
    {
        public static async Task<string> SaveProfilePhoto(IFormFile file, string username)
        {
            if (file == null || file.Length == 0) return null!;

            var extension = Path.GetExtension(file.FileName);
            var timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            var fileName = $"{username}{timestamp}{extension}";
            var folderPath = Path.Combine("wwwroot/images/profiles");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/images/profiles/{fileName}";
        }
    }
}
