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
                .Users
                .Where(x => x.Id == userId)
                .Select(x => new ProfileViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Gender = x.Gender,
                    ProfileImageUrl = x.ProfileImage,
                    Posts = x.Posts.Count,
                    Followers = x.Followers.Count,
                    Following = x.Following.Count,
                })
                .FirstOrDefaultAsync();
        }
    }
}
