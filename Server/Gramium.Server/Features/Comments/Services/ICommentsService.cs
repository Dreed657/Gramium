using System.Collections.Generic;
using System.Threading.Tasks;
using Gramium.Server.Features.Comments.Models;
using Gramium.Server.Infrastructure.Services;

namespace Gramium.Server.Features.Comments.Services
{
    public interface ICommentsService
    {
        Task<Result> Create(CreateCommentInputModel model, string userId);

        Task<Result> Update(int commentId, UpdateCommentInputModel model);

        Task<bool> Delete(int commentId);

        Task<CommentViewModel> GetById(int commentId);

        Task<IEnumerable<CommentViewModel>> GetAllComments();
        
        Task<IEnumerable<CommentViewModel>> GetAllByPostId(int postId);
    }
}
