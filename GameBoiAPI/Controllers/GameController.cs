using GameBoi.Models.Layer.DTOs;
using GameBoi.Models.Layer.DTOs.Games;
using GameBoi.Models.Layer.DTOs.MyGames;
using GameBoi.Models.Layer.DTOs.NewFolder;
using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameBoiAPI.Controllers
{
    [Authorize]
    [Route("api/game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;

        public GameController(IMapper mapper,
                              IUnitOfWork unitOfWork,
                              ICurrentUserService currentUserService,
                              IUserService userService,
                              IProfileService profileService)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _userService = userService;
            _profileService = profileService;
        }

        [HttpPost("add-my-game")]
        public async Task<IActionResult> AddToMyGames([FromBody] AddMyGameDto addMyGameDto)
        {
            var userId = _currentUserService.UserId;
            var profile = await _profileService.GetProfileByUsersId(userId);
           
            var newGame = new MyGame
            {
                ProfileId = profile.UserId,
                IGDB_id = addMyGameDto.IGDB_id,
                Name = addMyGameDto.Name,
                CoverImageUrl = addMyGameDto.CoverImageUrl,
                ReleaseDate = addMyGameDto.ReleaseDate,
                Genres = addMyGameDto.Genres,
                Platform = addMyGameDto.Platform,
                Status = addMyGameDto.Status,
                Review = addMyGameDto.Review,
                Rating = addMyGameDto.Rating,
                Platinum = addMyGameDto.Platinum,
                TrophyCount = addMyGameDto.TrophyCount
            };

            await _UnitOfWork.MyGameRepository.AddAsync(newGame);
            await _UnitOfWork.SaveChangesAsync();
            return Ok();

        }
        
    }
}
