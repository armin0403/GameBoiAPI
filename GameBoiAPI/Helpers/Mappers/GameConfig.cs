using GameBoi.Models.Layer.Models;
using GameBoi.Models.Layer.DTOs;
using Mapster;

namespace GameBoiAPI.Mappers
{
    public class GameConfig
    {
        public static void GameMapperConfig()
        {
            TypeAdapterConfig<CreateGameDto, GameDto>.NewConfig();
        }
    }
}
