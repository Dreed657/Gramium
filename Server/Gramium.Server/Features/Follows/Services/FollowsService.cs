using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Gramium.Server.Data;
using Gramium.Server.Data.Models;
using Gramium.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Gramium.Server.Features.Follows.Services
{
    public class FollowsService : IFollowsService
    {
        private readonly GramiumDbContext db;

        public FollowsService(GramiumDbContext db)
        {
            this.db = db;
        }
        
        public async Task<Result> Follow(string userId, string followerId)
        {
            if (userId == followerId)
            {
                return "You are trying to follow yourself!";
            }
            
            var isAlreadyFollower = await this.db.Follows
                .Where(x => !x.IsDeleted)
                .AnyAsync(x => x.UserId == userId && x.FollowerId == followerId);

            if (isAlreadyFollower)
            {
                return "This user is already followed.";
            }

            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return "User cannot be found!";
            }
            
            user.Followers.Add(new Follow()
            {
                UserId = userId,
                FollowerId = followerId,
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UnFollow(string userId, string followerId)
        {
            if (userId == followerId)
            {
                return "You are trying to unFollow yourself!";
            }

            var isAlreadyFollower = await this.db.Follows
                .Where(x => !x.IsDeleted)
                .AnyAsync(x => x.UserId == followerId && x.FollowerId == userId);

            if (isAlreadyFollower)
            {
                return "This user is not followed.";
            }
            
            var user = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return "User cannot be found!";
            }

            var followEntity = await this.db.Follows.FirstOrDefaultAsync(x => x.UserId == userId && x.FollowerId == followerId);

            if (followEntity == null)
            {
                return false;
            }

            this.db.Follows.Remove(followEntity);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsFollower(string userId, string followerId)
        {
            return await this.db.Follows.AnyAsync(x => x.UserId == userId && x.FollowerId == followerId);
        }
    }
}
