using System;
using System.Threading.Tasks;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Follows.Services;
using Gramium.Test.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Gramium.Test.Follows
{
    public class FollowsServiceTests : TestBase
    {
        [Fact]
        public async Task FollowShouldMakeNewRelation()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            var result = await service.Follow(userId, followerId);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task FollowShouldReturnAnErrorIfBothUserIdsAreEqual()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "You are trying to follow yourself!"; 
            
            var result = await service.Follow(userId, userId);

            var actualResult = result.Error;          
            
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task FollowShouldReturnAnErrorIfAlreadyRelationExists()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.Follows.AddAsync(new Follow() { UserId = userId, FollowerId =  followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "This user is already followed.";

            var result = await service.Follow(userId, followerId);

            var actualResult = result.Error;
                
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task FollowShouldReturnAnErrorIfUserDoesNotExists()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "User cannot be found!";

            var result = await service.Follow(Guid.NewGuid().ToString(), followerId);

            var actualResult = result.Error;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UnFollowShouldRemoveRelation()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.Follows.AddAsync(new Follow() { UserId = userId, FollowerId =  followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            var result = await service.UnFollow(userId, followerId);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task UnFollowShouldReturnAnErrorIfBothUserIdsAreEqual()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "You are trying to unFollow yourself!";

            var result = await service.UnFollow(userId, userId);

            var actualResult = result.Error;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UnFollowShouldReturnAnErrorIfAlreadyRelationNotExists()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "This user is not followed.";

            var result = await service.UnFollow(userId, followerId);

            var actualResult = result.Error;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UnFollowShouldReturnAnErrorIfUserDoesntExists()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            string expectedResult = "User cannot be found!";

            var result = await service.UnFollow(Guid.NewGuid().ToString(), followerId);

            var actualResult = result.Error;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UnFollowShouldReturnFalseIfRelationNotPresent()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            var followEntity = await db.Follows.FirstOrDefaultAsync(x => x.UserId == userId && x.FollowerId == followerId);
            
            var result = await service.UnFollow(userId, followerId);
            
            Assert.False(result.Succeeded);
            Assert.Null(followEntity);
        }

        [Fact]
        public async Task IsFollowerShouldReturnTrueIfUsersHaveRelation()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();
            
            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() {Id = userId});
            await db.Users.AddAsync(new ApplicationUser() {Id = followerId});
            await db.Follows.AddAsync(new Follow() { UserId = userId, FollowerId =  followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            var result = await service.IsFollower(userId, followerId);
            
            Assert.True(result);
        }

        [Fact]
        public async Task IsFollowerShouldReturnFalseIfUsersNotHaveRelation()
        {
            var userId = Guid.NewGuid().ToString();
            var followerId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Users.AddAsync(new ApplicationUser() { Id = followerId });
            await db.Follows.AddAsync(new Follow() { UserId = userId, FollowerId =  followerId });
            await db.SaveChangesAsync();

            var service = new FollowsService(db);

            var result = await service.IsFollower(userId, Guid.NewGuid().ToString());

            Assert.False(result);
        }
    }
}
