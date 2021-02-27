using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Features.Posts.Models;
using Gramium.Server.Features.Profiles.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Profiles.Services
{
    public class ProfileService : IProfileService
    {
        private readonly GramiumDbContext db;
        private readonly ICurrentUserService currentUser;

        public ProfileService(GramiumDbContext db, ICurrentUserService currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public async Task<ProfileViewModel> GetProfile(string username)
        {
            var user = await this.db
                .Users
                .Include(x => x.Posts)
                .Where(x => x.UserName == username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return new ProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = user.Gender,
                ProfileImageUrl = user.ProfileImage,
                PostsCount = user.Posts.Count,
                Posts = user.Posts.Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    ImageUrl = p.ImageUrl,
                    Likes = p.Likes.Count,
                    Comments = p.Comments.Count,
                    CreatedAt = p.CreatedOn,
                    isLiked = p.Likes
                        .Where(y => !y.IsDeleted)
                        .Any(y => y.UserId == this.currentUser.GetId())
                }).ToList(),
                Followers = user.Followers.Count,
                Following = user.Following.Count,
                IsFollowing = user.Id == this.currentUser.GetId()
                    ? null
                    : user.Followers
                        .Where(u => !u.IsDeleted)
                        .Any(u => u.FollowerId == this.currentUser.GetId())
            };
        }
    }
}
