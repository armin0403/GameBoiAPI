using Microsoft.AspNetCore.Http;

namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<string> SaveProfilePhotoAsync(IFormFile file, string username);
    }
}
