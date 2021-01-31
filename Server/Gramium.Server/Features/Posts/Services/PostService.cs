using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Posts.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Posts.Services
{
    public class PostService : IPostService
    {
        private readonly GramiumDbContext db;

        public PostService(GramiumDbContext db)
        {
            this.db = db;
        }
        
        public async Task<int> CreateAsync(string imageUrl, string content, string userId)
        {
            var post = new Post()
            {
                ImageUrl = imageUrl,
                Content = content,
                UserId = userId,
            };

            await this.db.Posts.AddAsync(post);
            await this.db.SaveChangesAsync();
            
            return post.Id;
        }

        public async Task<Result> UpdateAsync(int id, string content, string userId)
        {
            var post = await this.GetByIdAndByUserId(id, userId);

            if (post == null)
            {
                return "This user cannot update this post.";
            }

            post.Content = content;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id, string userId)
        {
            var post = await this.GetByIdAndByUserId(id, userId);

            if (post == null)
            {
                return "This user cannot delete this post.";
            }

            this.db.Posts.Remove(post);
            await this.db.SaveChangesAsync();

            return false;
        }

        public async Task<IEnumerable<PostListingModel>> ByUserAsync(string userId)
        {
            return await this.db
                .Posts
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new PostListingModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostListingModel>> GetAll()
        {
            return await this.db
                .Posts
                .Select(x => new PostListingModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<PostDetailViewModel> DetailsAsync(int id)
        {
            return await this.db
                .Posts
                .Where(x => x.Id == id)
                .Select(x => new PostDetailViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    UserId = x.UserId,
                    UserName = x.User.UserName
                })
                .FirstOrDefaultAsync();
        }

        private async Task<Post> GetByIdAndByUserId(int id, string userId)
        {
            return await this.db
                .Posts
                .Where(x => x.Id == id && x.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
