using GameBoi.Models.Layer.Models;
using Mapster;

namespace GameBoiAPI.Helpers.Mappers
{
    public static class ProfileMapping
    {
        public static void RegisterProfileMapping()
        {
            TypeAdapterConfig<User, Profile>
                .NewConfig()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.UserId, src => src.Id)
                .Ignore(dest => dest.MyGames);
        }
    }
}
