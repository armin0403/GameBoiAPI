using GameBoi.Services.Layer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameBoiAPI.Controllers
{
    /// <summary>
    /// We will use ProfileDto data here, only data that is publicly available 
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfileByUsername(string username)
        {
            var profile = await _userService.GetPublicProfileByUsernameAsync(username);
            if (profile == null)
                return NotFound(new { Message = "Profile not found." });

            return Ok(profile);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int id)
        {

            return Ok();
        }
    }
}
