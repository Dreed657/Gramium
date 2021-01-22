using System.Threading.Tasks;
using AutoMapper.Configuration;
using Gramium.Api.Common;
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
        private readonly IApiConfig apiConfig;

        public AuthController(IAuthService authService, IApiConfig apiConfig)
        {
            this.authService = authService;
            this.apiConfig = apiConfig;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(LoginResponseModel))]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            var validToken = await this.authService.AuthenticateUserAsync(model, this.apiConfig.JwtSecret);

            if (!string.IsNullOrEmpty(validToken))
            {
                //this.HttpContext.Response.Cookies.Append("auth", validToken);
                return Ok(new LoginResponseModel(validToken));
            }

            return Unauthorized();
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
