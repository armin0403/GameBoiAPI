using GameBoi.Repository.Layer.Repositories;
using GameBoi.Repository.Layer.Repositories.Interfaces;

namespace GameBoi.Repository.Layer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameBoiDbContext _dbContext;
        private IUserRepository _userRepository;
        private IMyGameRepository _myGameRepository;
        private IProfileRepository _profilerepository;

        public UnitOfWork(GameBoiDbContext dbContext)
        {
            _dbContext = dbContext;

            UserRepository = _userRepository ??= new UserRepository(_dbContext);
            MyGameRepository = _myGameRepository ??= new MyGameRepository(_dbContext);
            ProfileRepository = _profilerepository ??= new ProfileRepository(_dbContext);
        }

        public IUserRepository UserRepository { get; private set; }
        public IMyGameRepository MyGameRepository { get; private set; }

        public IProfileRepository ProfileRepository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
