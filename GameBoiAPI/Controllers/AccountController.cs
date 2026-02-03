using Microsoft.AspNetCore.Mvc;
using GameBoi.Models.Layer.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GameBoi.Services.Layer.Services.Interfaces;
using GameBoi.Repository.Layer.UnitOfWork;
using System.Threading.Tasks;
using Mapster;
using GameBoi.Models.Layer.DTOs;
using MapsterMapper;
using GameBoi.Models.Layer.Models;
using GameBoiAPI.Helpers.PasswordHelper;


namespace GameBoiAPI.Controllers
{

    /// <summary>
    /// We will use only User and UserDto on here, its private, protected data
    /// </summary>

    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountController(ICurrentUserService currentUserService,
                                 IUserService userService,
                                 IUnitOfWork unitOfWork,
                                 IMapper mapper
                                 )
        {
            _currentUserService = currentUserService;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("auth-debug")]
        public IActionResult DebugClaims([FromServices] ICurrentUserService currentUserService)
        {
            return Ok(new
            {
                ControllerUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                ServiceUserId = currentUserService.UserId,
                AllClaims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

        [Authorize]
        [HttpGet("current")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("User id is null.");

            return Ok($"Authenticated user ID: {userId}");
        }      

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail(ChangeEmailDto emailDto)
        {
            var user = await _userService.GetUserByUsernameOrEmail(_currentUserService.Email!);
            if (user == null)
                return NotFound("User not found.");

            if(user.Email == emailDto.CurrentEmail)
            {
                if(await _userService.EmailExists(emailDto.NewEmail))
                {
                    return BadRequest("Email already in use.");
                }
                user.Email = emailDto.NewEmail;
                await _unitOfWork.SaveChangesAsync();
                return Ok("Successfuly changed email");
            }
            return BadRequest("Your current mail is wrong / your new email can't be same as current email");            
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var user = await _userService.GetUserByUsernameOrEmail(passwordDto.Email);
            if (user == null)
                return NotFound("User not found.");

            if(!PasswordHelper.ValidatePassword(passwordDto.CurrentPassword, user.PasswordSalt, user.PasswordHash))
                return BadRequest("Current password not correct.");

            if (passwordDto.NewPassword != passwordDto.ConfirmNewPassword)
                return BadRequest("Please confirm your new passowrd.");

            var newSalt = PasswordHelper.CreateSalt();
            var newHash = PasswordHelper.CreateHash(passwordDto.NewPassword, newSalt);

            user.PasswordSalt = newSalt;
            user.PasswordHash = newHash;

            await _unitOfWork.SaveChangesAsync();
            return Ok("Password changed.");
        }
    }
}
