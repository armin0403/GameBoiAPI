using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using GameBoi.Models.Layer.DTOs;
using GameBoi.Models.Layer.Models;
using GameBoi.Services.Layer.Services.Interfaces;
using GameBoi.Services.Layer.Services.JWT_Auth;
using GameBoiAPI.Helpers.PasswordHelper;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace GameBoiAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IValidator<UserRegisterDto> _registerValidator;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly JwtTokenGenerator _jwt;

        public UserController(IValidator<UserRegisterDto> registerValidator,
                              IMapper mapper,
                              IUserService userService,
                              IProfileService profileService,
                              JwtTokenGenerator jwt)
        {
            _registerValidator = registerValidator;
            _mapper = mapper;
            _userService = userService;
            _profileService = profileService;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLoginDto)
        {
            ModelState.Clear();
            var user = await _userService.GetUserByUsernameOrEmail(userLoginDto.UsernameOrEmail);
            if(user == null || userLoginDto.Password == null)
            {
                ModelState.AddModelError(string.Empty, "Password or username/email incorrect!");
                return ValidationProblem(ModelState);
            }

            var passwordHash = PasswordHelper.CreateHash(userLoginDto.Password, user.PasswordSalt);
            if(user.PasswordHash != passwordHash)
            {
                ModelState.AddModelError(string.Empty, "Password or username/email incorrect!");
                return ValidationProblem(ModelState);
            }

            var token = _jwt.GenerateToken(user.Id.ToString(), user.Username, user.Email);

            return Ok(new
            {
                accessToken = token.Token,
                expiresAt = token.Expiration
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto registerUser)
        {
            ModelState.Clear();
            ValidationResult result = await _registerValidator.ValidateAsync(registerUser);
            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }

            var passwordSalt = PasswordHelper.CreateSalt();
            var passwordHash = PasswordHelper.CreateHash(registerUser.Password, passwordSalt);

            var user = registerUser.Adapt<User>();
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            await _userService.Add(user);

            var profile = user.Adapt<Profile>();
            await _profileService.Add(profile);

            return Ok();
        }

        [Authorize]
        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("User id is null.");
           
            return Ok($"Authenticated user ID: {userId}");
        }

        [Authorize]
        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }
    }
}
