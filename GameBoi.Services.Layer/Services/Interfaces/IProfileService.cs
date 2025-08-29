using GameBoi.Models.Layer.Models;

namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfileByUsersId(int? id);
        Task<bool> Add(Profile profile);
    }
}
