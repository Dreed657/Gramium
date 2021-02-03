using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Features.Profiles.Models;
using Gramium.Server.Features.Profiles.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileService profile;
        private readonly ICurrentUserService current;

        public ProfilesController(IProfileService profile, ICurrentUserService current)
        {
            this.profile = profile;
            this.current = current;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await this.profile.GetProfile(this.current.GetId()));
        }
    }
}
