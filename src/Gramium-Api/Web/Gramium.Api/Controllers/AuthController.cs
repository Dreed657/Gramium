using System.Threading.Tasks;
using AutoMapper.Configuration;
using Gramium.Data.Models;
using Gramium.Services.Authentication;
using Gramium.Web.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Gramium.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // TODO: REMOVE HARD CODED SECRET
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            IActionResult response = Unauthorized();
            var validToken = await this.authService.AuthenticateUserAsync(model, "gjqqxpe5udpcc8g4");

            if (!string.IsNullOrEmpty(validToken))
            {
                this.HttpContext.Response.Cookies.Append("auth", validToken);
                response = Ok(new { token = validToken });
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var result = await this.authService.RegisterUser(model);
            if (!result)
            {
                return BadRequest("Something went very wrong with your request!");
            }
            
            return Ok();
        }
    }
}
