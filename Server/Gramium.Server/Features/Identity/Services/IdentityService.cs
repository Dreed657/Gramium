using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Features.Identity.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace Gramium.Server.Features.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ICurrentUserService currentUser;
        private readonly GramiumDbContext db;

        public IdentityService(ICurrentUserService currentUser, GramiumDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public AuthenticateViewModel Authenticate()
        {
            return this.db
                .Users
                .Select(x => new AuthenticateViewModel()
                {
                    id = x.Id,
                    username = x.UserName,
                    profileImageUrl = x.ProfileImage
                })
                .FirstOrDefault(x => x.id == this.currentUser.GetId());
        }

        public string GenerateJwtToken(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
