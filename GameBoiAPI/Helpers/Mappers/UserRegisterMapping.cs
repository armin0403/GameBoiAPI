using GameBoi.Models.Layer.DTOs;
using GameBoi.Models.Layer.Models;
using Mapster;

namespace GameBoiAPI.Helpers.Mappers
{
    public static class UserRegisterMapping
    {
        public static void RegisterUserRegisterMapping()
        {
            TypeAdapterConfig<UserRegisterDto, User>.NewConfig()
                .Ignore(dest => dest.Profile);              
            
        }
    }
}
