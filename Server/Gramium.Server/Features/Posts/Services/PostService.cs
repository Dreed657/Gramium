﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Comments.Models;
using Gramium.Server.Features.Identity.Models;
using Gramium.Server.Features.Likes.Services;
using Gramium.Server.Features.Posts.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Posts.Services
{
    public class PostService : IPostService
    {
        private readonly GramiumDbContext db;
        private readonly ICurrentUserService currentUser;

        public PostService(GramiumDbContext db, ICurrentUserService currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
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

        public async Task<IEnumerable<PostViewModel>> ByUserAsync(string userId)
        {
            return await this.db
                .Posts
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    Likes = x.Likes.Count(y => !y.IsDeleted),
                    Comments = x.Comments.Count(y => !y.IsDeleted),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetAllAsync()
        {
            return await this.db
                .Posts
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    User = new ShortUserViewModel()
                    {
                        Id = x.UserId,
                        Username = x.User.UserName,
                        ProfileImageUrl = x.User.ProfileImage,
                    },
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    Likes = x.Likes.Count(y => !y.IsDeleted),
                    Comments = x.Comments.Count(y => !y.IsDeleted),
                    CreatedAt = x.CreatedOn,
                    isLiked = x.Likes
                        .Where(y => !y.IsDeleted)
                        .Any(y => y.UserId == this.currentUser.GetId()),
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
                    UserName = x.User.UserName,
                    CommentsCount = x.Comments.Count(y => !y.IsDeleted),
                    CreatedOn = x.CreatedOn,
                    Comments = x.Comments.Select(c => new CommentViewModel()
                    {
                        UserName = c.User.UserName,
                        Content = c.Content,
                        CreatedAt = c.CreatedOn,
                    }).ToList(),
                    Likes = x.Likes.Count(y => !y.IsDeleted),
                    isLiked = x.Likes
                        .Where(y => !y.IsDeleted)
                        .Any(y => y.UserId == this.currentUser.GetId()),
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
