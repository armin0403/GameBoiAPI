using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameBoi.Repository.Layer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly GameBoiDbContext _dbContext;
        public UserRepository(GameBoiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<User?> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
