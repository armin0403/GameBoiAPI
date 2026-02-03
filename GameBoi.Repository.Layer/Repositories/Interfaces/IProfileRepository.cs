using GameBoi.Models.Layer.Models;

namespace GameBoi.Repository.Layer.Repositories.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<Profile> FindProfileByUserIdAsync(int? id);
    }
}
