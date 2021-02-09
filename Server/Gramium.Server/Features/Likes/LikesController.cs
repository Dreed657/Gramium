using System.Threading.Tasks;
using Gramium.Server.Features.Likes.Models;
using Gramium.Server.Features.Likes.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Server.Features.Likes
{
    public class LikesController : ApiController
    {
        private readonly ILikesService likes;
        private readonly ICurrentUserService currentUser;

        public LikesController(ILikesService likes, ICurrentUserService currentUser)
        {
            this.likes = likes;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<IActionResult> Like(LikeInputModel model)
        {
            var result = await this.likes.Like(model.postId, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UnLike(LikeInputModel model)
        {
            var result = await this.likes.UnLike(model.postId, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
