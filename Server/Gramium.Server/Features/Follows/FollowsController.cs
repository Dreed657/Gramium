using Gramium.Server.Features.Follows.Services;

namespace Gramium.Server.Features.Follows
{
    public class FollowsController : ApiController
    {
        private readonly IFollowsService follow;

        public FollowsController(IFollowsService follow)
        {
            this.follow = follow;
        }
    }
}
