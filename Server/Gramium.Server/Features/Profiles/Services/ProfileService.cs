using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Features.Posts.Models;
using Gramium.Server.Features.Profiles.Models;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Profiles.Services
{
    public class ProfileService : IProfileService
    {
        private readonly GramiumDbContext db;

        public ProfileService(GramiumDbContext db)
        {
            this.db = db;
        }
        
        public async Task<ProfileViewModel> GetProfile(string userId)
        {
            return await this.db
                .Profiles
                .Where(x => x.userId == userId)
                .Select(x => new ProfileViewModel()
                {
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    UserName = x.User.UserName,
                    Gender = x.Gender,
                    ProfileImageUrl = x.ProfileImage,
                    Posts = x.User.Posts.Count,
                    Followers = x.User.Followers.Count,
                    Following = x.User.Following.Count,
                })
                .FirstOrDefaultAsync();
        }
    }
}
