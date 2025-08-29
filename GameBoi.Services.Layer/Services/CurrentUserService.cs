using System.Security.Claims;
using GameBoi.Services.Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GameBoi.Services.Layer.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int? UserId 
        {
            get 
            {
                var id = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return int.TryParse(id, out var intId) ? intId : null;
            } 
        }
        public string? Username =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public string? Email =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

    }
}
