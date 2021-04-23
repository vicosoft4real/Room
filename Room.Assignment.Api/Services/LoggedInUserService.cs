using Microsoft.AspNetCore.Http;
using Room.Assignment.Application.Contracts.Identity;
using System.Security.Claims;

namespace Room.Assignment.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggedInUserService : ILoggedInUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; }
    }
}
