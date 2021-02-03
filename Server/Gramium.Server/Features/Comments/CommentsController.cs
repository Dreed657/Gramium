using System.Threading.Tasks;
using Gramium.Server.Features.Comments.Models;
using Gramium.Server.Features.Comments.Services;
using Gramium.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Server.Features.Comments
{
    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;
        private readonly ICurrentUserService currentUser;

        public CommentsController(ICommentsService comments, ICurrentUserService currentUser)
        {
            this.comments = comments;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.comments.GetAllComments();
            
            if (result == null)
            {
                return BadRequest("No comments in the database!");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.comments.GetById(id);

            if (result == null)
            {
                return BadRequest("Cannot find the comment!");
            }

            return Ok(result);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetByPostId(int postId)
        {
            var result = await this.comments.GetAllByPostId(postId);

            if (result == null)
            {
                return BadRequest("Cannot find the comment!");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel model)
        {
            var result = await this.comments.Create(model, this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }
            
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateCommentInputModel model)
        {
            var result = await this.comments.Update(id, model);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.comments.Delete(id);

            if (!result)
            {
                return BadRequest("Something went wrong with your request!");
            }

            return Ok();
        }
    }
}
