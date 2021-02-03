using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Likes.Services
{
    public class LikesService : ILikesService
    {
        private readonly GramiumDbContext db;

        public LikesService(GramiumDbContext db)
        {
            this.db = db;
        }

        public async Task<Result> Like(int postId, string userId)
        {
            var likeEntity = await this.db.Likes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);

            if (likeEntity == null)
            {
                var entity = new Like()
                {
                    UserId = userId,
                    PostId = postId,
                };

                await this.db.Likes.AddAsync(entity);
            }
            
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UnLike(int postId, string userId)
        {
            var likeEntity = await this.db.Likes.FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);

            if (likeEntity == null)
            {
                return "This post isn't liked by user!";
            }

            this.db.Likes.Remove(likeEntity);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsLike(int postId, string userId)
        {
            return await this.db.Likes.AnyAsync(x => x.UserId == userId && x.PostId == postId);
        }
    }
}
