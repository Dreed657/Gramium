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
            return await this.db
                .Users
                .Where(x => x.UserName == username)
                .Select(x => new ProfileViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Gender = x.Gender,
                    ProfileImageUrl = x.ProfileImage,
                    PostsCount = x.Posts.Count,
                    Posts = x.Posts.Select(p => new PostViewModel() { 
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
                    Followers = x.Followers.Count,
                    Following = x.Following.Count,
                })
                .FirstOrDefaultAsync();
        }
    }
}
