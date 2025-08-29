using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.Models;

namespace GameBoi.Services.Layer.Services.Interfaces
{
    public interface IMyGameService
    {
        Task<bool> AddMyGame(MyGame game);
    }
}
