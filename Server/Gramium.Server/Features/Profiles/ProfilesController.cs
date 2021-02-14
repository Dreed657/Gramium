using System.Threading.Tasks;
using Gramium.Server.Features.Profiles.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profile;

        public ProfilesController(IProfileService profile)
        {
            this.profile = profile;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string username)
        {
            var result = await this.profile.GetProfile(username);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
