using GameBoi.Models.Layer.DTOs;
using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services.Interfaces;
using Mapster;

namespace GameBoi.Services.Layer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Profile profile)
        {
            await UnitOfWork.ProfileRepository.AddAsync(profile);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<Profile> GetProfileByUsersId(int? id)
        {
            var profile = UnitOfWork.ProfileRepository.FindProfileByUserIdAsync(id);
            if (profile == null)
                throw new Exception("Profile not found for user ID:" + id);

            return profile;
        }
    }
}
