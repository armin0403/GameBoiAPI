using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.Repositories.Interfaces;

namespace GameBoi.Repository.Layer.Repositories
{
    public class MyGameRepository : BaseRepository<MyGame>, IMyGameRepository
    {
        public MyGameRepository(GameBoiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
