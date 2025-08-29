using GameBoi.Repository.Layer.Repositories.Interfaces;

namespace GameBoi.Repository.Layer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMyGameRepository MyGameRepository { get; }
        IUserRepository UserRepository { get; }
        IProfileRepository ProfileRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
