using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services.Interfaces;
using GameBoiAPI.Helpers.FileHandler;
using Microsoft.AspNetCore.Http;

namespace GameBoi.Services.Layer.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> SaveProfilePhotoAsync(IFormFile file, string username)
        {
            var user = await _unitOfWork.UserRepository.GetByUsernameAsync(username);
            var profile = await _unitOfWork.ProfileRepository.FindProfileByUserIdAsync(user.Id);

            if(profile != null && !string.IsNullOrEmpty(profile.ProfileImageUrl))
            {
                var oldFilePath = Path.Combine("wwwroot", profile.ProfileImageUrl.TrimStart('/'));
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            var path = await FileHandler.SaveProfilePhoto(file, username);
           
            if(profile != null)
            {
                profile.ProfileImageUrl = path;
                await _unitOfWork.ProfileRepository.UpdateAsync(profile);
                await _unitOfWork.SaveChangesAsync();
            }

            return path;
        }
    }
}
