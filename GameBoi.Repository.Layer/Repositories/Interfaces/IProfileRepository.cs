using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBoi.Models.Layer.Models;

namespace GameBoi.Repository.Layer.Repositories.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<Profile> FindProfileByUserIdAsync(int? id);
    }
}
