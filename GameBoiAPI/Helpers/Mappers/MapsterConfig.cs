using GameBoiAPI.Helpers.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GameBoiAPI.Mappers
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection service)
        {
            GameConfig.GameMapperConfig();
            IGDBMappingGames.RegisterIGDBMappingGames();
            UserRegisterMapping.RegisterUserRegisterMapping();
            ProfileMapping.RegisterProfileMapping();
        }
    }
}
