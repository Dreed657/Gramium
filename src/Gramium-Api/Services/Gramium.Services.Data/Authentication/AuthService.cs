using System;
using System.Security.Claims;
using System.Text;
using Gramium.Web.ViewModels.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Gramium.Services.Authentication
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    using Gramium.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> AuthenticateUserAsync(UserLoginModel model, string jwtSecret)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return null;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return null;
            }

            var token = GenerateJwt(user.Id, user.UserName, jwtSecret);

            return token;
        }

        public async Task<bool> RegisterUser(UserRegisterModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            // TODO: Add Validations
            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        private static string GenerateJwt(string userId, string userName, string jwtSecret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
