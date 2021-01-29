using System.Security.Claims;
using System.Threading.Tasks;
using Gramium.Services.Data.Authentication.CurrentUser;
using Gramium.Services.Data.Users;
using Gramium.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Api.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IUsersService usersService;

        public UsersController(ICurrentUserService currentUserService, IUsersService usersService)
        {
            this.currentUserService = currentUserService;
            this.usersService = usersService;
        }

        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrent()
        {
            var user = await this.usersService.GetUserByIdAsync<UserViewModel>(this.currentUserService.GetId());
            
            return Ok(user);
        }
    }
}
