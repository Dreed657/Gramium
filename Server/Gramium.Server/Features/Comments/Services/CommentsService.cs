using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Comments.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Comments.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly GramiumDbContext db;

        public CommentsService(GramiumDbContext db)
        {
            this.db = db;
        }

        public async Task<CommentViewModel> Create(CreateCommentInputModel model, string userId)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException("User does not exists!");
            }

            var post = await this.db.Posts.FirstOrDefaultAsync(x => x.Id == model.postId);

            if (post == null)
            {
                throw new InvalidOperationException("Post does not exists!");
            }

            var commentEntity = new Comment()
            {
                Content = model.Content,
                Post = post,
                User = user,
            };

            await this.db.Comments.AddAsync(commentEntity);
            await this.db.SaveChangesAsync();

            // TODO: A FUCKING AUTO MAPPER
            // TODO: REFACTOR MEEEE
            return new CommentViewModel() 
            { 
                Content = commentEntity.Content,
                CreatedAt = commentEntity.CreatedOn,
                UserName = commentEntity.User.UserName,
            };
        }

        public async Task<Result> Update(int commentId, UpdateCommentInputModel model)
        {
            var comment = await this.db.Comments.FirstOrDefaultAsync(x => x.Id == commentId);

            if (comment == null)
            {
                return "Comment with this ID cannot be found!";
            }

            comment.Content = model.Content;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int commentId)
        {
            var comment = await this.db.Comments.FirstOrDefaultAsync(x => x.Id == commentId);

            if (comment == null)
            {
                return false;
            }

            this.db.Comments.Remove(comment);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<CommentViewModel> GetById(int commentId)
        {
            return await this.db.Comments
                .Where(x => x.Id == commentId)
                .Select(x => new CommentViewModel()
                {
                    Content = x.Content,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllComments()
        {
            return await this.db.Comments
                .Select(x => new CommentViewModel()
                {
                    Content = x.Content,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllByPostId(int postId)
        {
            return await this.db.Comments
                .Where(x => x.PostId == postId)
                .Select(x => new CommentViewModel()
                {
                    Content = x.Content,
                })
                .ToListAsync();
        }
    }
}
