using System.Security.Claims;
using System.Threading.Tasks;
using Gramium.Services.Data.Authentication.CurrentUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly ICurrentUserService currentUserService;

        public UsersController(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }

        [HttpGet]
        public IActionResult GetCurrent()
        {
            return Ok();
        }
    }
}
