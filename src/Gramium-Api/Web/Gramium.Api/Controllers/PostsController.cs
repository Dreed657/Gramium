using Gramium.Services.Data.Posts;
using Gramium.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Services.Data.Authentication.CurrentUser;

namespace Gramium.Api.Controllers
{
    [Authorize]
    public class PostsController : ApiController
    {
        private readonly IPostsService postsService;
        private readonly ICurrentUserService currentUser;

        public PostsController(IPostsService postsService, ICurrentUserService currentUser)
        {
            this.postsService = postsService;
            this.currentUser = currentUser;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await this.postsService.GetByIdAsync<PostViewModel>(id);

            if (post == null)
            {
                return this.BadRequest();
            }

            return this.Ok(post);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var posts = await this.postsService.GetAllAsync<PostViewModel>();

            if (!posts.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(posts);
        }

        [HttpGet("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var posts = await this.postsService.GetAllByUserIdAsync<PostViewModel>(userId);

            if (!posts.Any())
            {
                return this.BadRequest();
            }

            return this.Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostInputModel model)
        {
            var userId = this.currentUser.GetId();
            var result = await this.postsService.CreateAsync<PostViewModel>(model, userId);

            if (result == null)
            {
                return this.BadRequest();
            }

            return this.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.postsService.DeleteAsync(id);

            if (!result)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> Update([FromBody] PostInputModel model, int postId)
        {
            var result = await this.postsService.UpdateAsync(model, postId);

            if (!result)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}
