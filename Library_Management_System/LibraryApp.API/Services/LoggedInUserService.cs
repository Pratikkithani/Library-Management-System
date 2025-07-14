using System.Security.Claims;
using LibraryApp.Application.Interfaces;

namespace LibraryApp.API.Services
{
    public class LoggedInUserService :ILoggedInUserService
    {
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor contextAccessor)
        {
            UserId = contextAccessor.HttpContext?.User?.FindFirst("uid")?.Value ?? string.Empty;

        }
    }
}
