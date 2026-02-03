using System.Linq;
using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.DTOs.NewFolder;
using Mapster;

namespace GameBoiAPI.Helpers.Mappers
{
    public static class IGDBMappingGames
    {
        public static void RegisterIGDBMappingGames()
        {
            TypeAdapterConfig<IGDBGameDto, MyGameDto>
                .NewConfig()
                .Map(dest => dest.IGDB_id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CoverImageUrl, src => src.Url)
                .Map(dest => dest.ReleaseDate, src => src.ReleaseDate)
                .Map(dest => dest.Genres, src => string.Join(", ", src.GenreNames ?? Enumerable.Empty<string>()))
                .Map(dest => dest.Platform, src => string.Join(", ", src.PlatformNames ?? Enumerable.Empty<string>()))
                .Ignore(dest => dest.Review)
                .Ignore(dest => dest.Rating)
                .Ignore(dest => dest.TrophyCount)
                .Ignore(dest => dest.Platinum)
                .Ignore(dest => dest.UserId)
                .Ignore(dest => dest.Status);
        }
    }
}
