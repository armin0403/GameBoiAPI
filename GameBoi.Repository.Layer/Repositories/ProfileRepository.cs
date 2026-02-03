using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameBoi.Repository.Layer.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(GameBoiDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Profile> FindProfileByUserIdAsync(int? id)
        {
            return await _dbContext.Profiles.Include(p => p.User).FirstOrDefaultAsync(p => p.UserId == id);
        }
    }
}
