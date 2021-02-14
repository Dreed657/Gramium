using System.Threading.Tasks;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Follows.Models;
using Gramium.Server.Features.Follows.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Server.Features.Follows
{
    public class FollowsController : ApiController
    {
        private readonly IFollowsService follow;
        private readonly ICurrentUserService currentUser;

        public FollowsController(IFollowsService follow, ICurrentUserService currentUser)
        {
            this.follow = follow;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowInputModel model)
        {
            var result = await this.follow.Follow(model.userId, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }
            
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> UnFollow(UnFollowInputModel model)
        {
            var result = await this.follow.UnFollow(model.userId, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
