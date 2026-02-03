using GameBoi.Models.Layer.DTOs.Profile;
using GameBoi.Models.Layer.Models;
using GameBoi.Repository.Layer.UnitOfWork;
using GameBoi.Services.Layer.Services;
using GameBoi.Services.Layer.Services.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameBoiAPI.Controllers
{
    
    [AllowAnonymous]
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileController(IProfileService profileService,
                                IUserService userService,
                                IPhotoService photoService,
                                ICurrentUserService currentUserService,
                                IMapper mapper,
                                IUnitOfWork unitOfWork)
        {
            _profileService = profileService;
            _userService = userService;
            _photoService = photoService;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("u/{username}")]
        public async Task<IActionResult> GetProfileByUsername(string? username)
        {
            var user = await _userService.GetUserByUsernameOrEmail(username);
            if (user == null)
                return NotFound(new { Message = "User not found." });

            var profile = await _profileService.GetProfileByUsersId(user.Id);
            if (profile == null)
                return NotFound(new { Message = "Profile not found." });

            var profileDto = profile.Adapt<ProfileDto>();
            profileDto.FirstName = user.FirstName;
            profileDto.LastName = user.LastName;
            profileDto.Username = user.Username;
            profileDto.DateOfBirth = user.DateOfBirth;

            return Ok(profileDto);
        }

        [Authorize]
        [HttpPut("update-profile-personal-info/{username}")]
        public async Task<IActionResult> UpdateProfilePersonalInfo(string username, [FromBody] ProfilePersonalInfoDto personalInfoDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameOrEmailAsync(username);
            if (user == null) return NotFound($"User '{username}'not found!");

            user.FirstName = personalInfoDto.FirstName;
            user.LastName = personalInfoDto.LastName;
            user.DateOfBirth = personalInfoDto.DateOfBirth;

            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { message = "Personal info updated successfully" });
        }

        [Authorize]
        [HttpPut("update-profile-details-info/{username}")]
        public async Task<IActionResult> UpdateProfileDetailsInfo(string username, [FromBody] ProfileDetailsInfoDto detailsInfoDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameOrEmailAsync(username);
                if (user == null) return NotFound($"User '{username}' not found!");
            var profile = await _unitOfWork.ProfileRepository.FindProfileByUserIdAsync(user.Id);
                if (profile == null) return NotFound($"Profile not found!");

            profile.Gamertag = detailsInfoDto.Gamertag;
            profile.Biography = detailsInfoDto.Biography;
            profile.Country = detailsInfoDto.Country;
            profile.FavPlatform = detailsInfoDto.FavPlatform;
            profile.FavGenre = detailsInfoDto.FavGenre;

            await _unitOfWork.ProfileRepository.UpdateAsync(profile);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { message = "Additional info updated successfully" });
        }

        [HttpPost("upload-profile-photo")]
        public async Task<IActionResult> UploadProfilePhoto([FromForm] ProfilePhotoUploadDto dto)
        {
            if (dto.File == null || string.IsNullOrEmpty(dto.Username))
                return BadRequest("File and username are required.");

            var url = await _photoService.SaveProfilePhotoAsync(dto.File, dto.Username);

            return Ok(new { imageUrl = url });
        }

    }
}
