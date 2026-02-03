using System.Security.Claims;
using GameBoi.Models.Layer.DTOs.Profile;
using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace GameBoi.Services.Layer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUserService _currentUserService;

        public UserService(IUnitOfWork unitOfWork,
                           IHttpContextAccessor httpContextAccessor,
                           ICurrentUserService currentUserService)
        {
            this.UnitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Add(User user)
        {
            await UnitOfWork.UserRepository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
       
        public Task<bool> EmailExists(string email)
        {
            return UnitOfWork.UserRepository.EmailExistsAsync(email);
        }

        public async Task<ProfileDto> GetPublicProfileByUsernameAsync(string username)
        {
            var user = await UnitOfWork.UserRepository.GetByUsernameAsync(username);
            if (user == null)
                return null;

            return user.Adapt<ProfileDto>();
        }

        public async Task<User> GetUserById(int id)
        {
            return await UnitOfWork.UserRepository.GetById(id);
        }

        public async Task<User> GetUserByUsernameOrEmail(string usernameOrEmail)
        {
            return await UnitOfWork.UserRepository.GetUserByUsernameOrEmailAsync(usernameOrEmail);
        }

        public Task<bool> UsernameExists(string username)
        {
            return UnitOfWork.UserRepository.UsernameExistsAsync(username);
        }
    }
}
