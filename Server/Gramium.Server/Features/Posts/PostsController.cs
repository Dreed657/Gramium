using System.Collections;

namespace Gramium.Server.Features.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Services;
    using Gramium.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Mvc;

    using static Infrastructure.WebConstants;
    
    public class PostsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IPostService posts;

        public PostsController(ICurrentUserService currentUser, IPostService posts)
        {
            this.currentUser = currentUser;
            this.posts = posts;
        }

        [HttpGet]
        public async Task<IEnumerable<PostViewModel>> GetAll()
        {
            return await this.posts.GetAllAsync();
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<PostDetailViewModel>> Details(int id)
        {
            var result = await this.posts.DetailsAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePostRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.posts.CreateAsync(
                model.ImageUrl,
                model.Content,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id, UpdatePostRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.posts.UpdateAsync(
                id,
                model.Content,
                userId);

            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var result = await this.posts.DeleteAsync(id, userId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
