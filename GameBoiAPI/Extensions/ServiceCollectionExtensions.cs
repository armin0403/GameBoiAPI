using Microsoft.EntityFrameworkCore;
using GameBoi.Repository.Layer;
using MapsterMapper;
using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services;
using GameBoi.Services.Layer.Services.Interfaces;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestEase;
using GameBoi.Services.Layer.Services.IGDB_API_CALLS.Interfaces;
using FluentValidation;
using GameBoi.Models.Layer.DTOs;
using GameBoiAPI.Validators;
using GameBoi.Services.Layer.Services.JWT_Auth;
using Mapster;


namespace GameBoiAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameBoiDbContext>((sp, opts) =>
            {
                opts.UseNpgsql(sp.GetRequiredService<IConfiguration>().GetConnectionString("GameBoi Connection"));
            });


            //Auth
            services.AddScoped<JwtTokenGenerator>();

            //apiCalls
            services.AddSingleton<IIGDB_API>(sp =>
            {
                return new RestClient("https://api.igdb.com")
                {
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    }
                }.For<IIGDB_API>();
            });

            //validations
            services.AddScoped<IValidator<UserRegisterDto>, UserRegisterValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();

            //repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<HelperServices>();

            //extensions
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, Mapper>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
