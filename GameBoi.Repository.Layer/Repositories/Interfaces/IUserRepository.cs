using GameBoi.Models.Layer.Models;

namespace GameBoi.Repository.Layer.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> UsernameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
        Task<User> GetByUsernameAsync(string username);
    }
}
