using System.Linq;

namespace Gramium.Services.Data.Authentication.CurrentUser
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public string GetUserName()
        {
            return this.user?.Identity?.Name;
        }

        public string GetId()
        {
            return this.user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
