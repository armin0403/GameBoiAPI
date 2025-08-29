
using GameBoi.Models.Layer.DTOs;
using GameBoi.Models.Layer.Models;

namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsernameOrEmail(string usernameOrEmail);
        Task<bool> Add(User user);
        Task<bool> UsernameExists(string username);
        Task<bool> EmailExists(string email);
        Task<ProfileDto> GetPublicProfileByUsernameAsync(string username);

    }
}
