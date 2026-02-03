using GameBoi.Models.Layer.DTOs.Profile;
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


            TypeAdapterConfig<Profile, ProfileDto>
                .NewConfig()
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName)
                .Map(dest => dest.Username, src => src.User.Username)
                .Map(dest => dest.ProfileImageUrl, src => src.ProfileImageUrl)
                .Map(dest => dest.Biography, src => src.Biography)
                .Map(dest => dest.Country, src => src.Country)
                .Map(dest => dest.Gamertag, src => src.Gamertag)
                .Map(dest => dest.FavPlatform, src => src.FavPlatform)
                .Map(dest => dest.FavGenre, src => src.FavGenre);

            TypeAdapterConfig<ProfileDto, Profile>
                .NewConfig()
                .Map(dest => dest.User.FirstName, src => src.FirstName)
                .Map(dest => dest.User.LastName, src => src.LastName)
                .Map(dest => dest.User.Username, src => src.Username)
                .Map(dest => dest.ProfileImageUrl, src => src.ProfileImageUrl)
                .Map(dest => dest.Biography, src => src.Biography)
                .Map(dest => dest.Country, src => src.Country)
                .Map(dest => dest.Gamertag, src => src.Gamertag)
                .Map(dest => dest.FavPlatform, src => src.FavPlatform)
                .Map(dest => dest.FavGenre, src => src.FavGenre);

            TypeAdapterConfig<UpdateProfileDto, Profile>
                .NewConfig()
                .IgnoreNullValues(true)
                .Map(dest => dest.Biography, src => src.Biography)
                .Map(dest => dest.Country, src => src.Country)
                .Map(dest => dest.Gamertag, src => src.Gamertag)
                .Map(dest => dest.FavPlatform, src => src.FavPlatform)
                .Map(dest => dest.FavGenre, src => src.FavGenre);
        }
    }
}
