using System;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Likes.Services;
using Gramium.Test.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Gramium.Test.Likes
{
    public class LikesServiceTests : TestBase
    {
        [Fact]
        public async Task IsLikeShouldReturnFalseIfPostIsNotLiked()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() {Id = userId});
            await db.Posts.AddAsync(new Post() {Id = postId, UserId = userId});
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            var result = await service.IsLike(postId, userId);
            
            Assert.False(result);
        }

        [Fact]
        public async Task IsLikeShouldReturnTrueIfPostIsLiked()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = postId, UserId = userId });
            await db.Likes.AddAsync(new Like() { PostId = postId, UserId = userId});
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            var result = await service.IsLike(postId, userId);

            Assert.True(result);
        }

        [Fact]
        public async Task UnLikeShouldRemoveLikeEntity()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = postId, UserId = userId });
            await db.Likes.AddAsync(new Like() { PostId = postId, UserId = userId });
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            var expectedResult = db.Likes.Count(x => !x.IsDeleted) - 1;
            
            var result = await service.UnLike(postId, userId);
            
            var actualResult = db.Likes.Count(x => !x.IsDeleted);

            Assert.True(result.Succeeded);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UnLikeShouldReturnAnErrorIfLikeEntityDoesntExists()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = postId, UserId = userId });
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            string expectedResult = "This post isn't liked by user!";

            var result = await service.UnLike(postId, userId);

            var actualResult = result.Error;
            
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task LikeShouldAddLikeEntity()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = postId, UserId = userId });
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            var expectedCount = db.Likes.CountAsync(x => !x.IsDeleted).GetAwaiter().GetResult() + 1;
            
            var result = await service.Like(postId, userId);

            var actualCount = await db.Likes.CountAsync(x => !x.IsDeleted);

            Assert.True(result.Succeeded);
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public async Task LikeShouldUnSoftDeleteEntity()
        {
            var userId = Guid.NewGuid().ToString();
            var postId = 1;

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = postId, UserId = userId });
            await db.Likes.AddAsync(new Like() { UserId = userId, PostId = postId, IsDeleted = true, DeletedOn = DateTime.Now});
            await db.SaveChangesAsync();

            var service = new LikesService(db);

            var expectedDeleteStatus = db.Likes.FirstOrDefault(x => x.UserId == userId && x.PostId == postId).IsDeleted;
            var expectedResult = db.Likes.Count(x => !x.IsDeleted) + 1;
            var result = await service.Like(postId, userId);
            var actualResult = db.Likes.Count();
            var actualDeleteStatus = db.Likes.FirstOrDefault(x => x.UserId == userId && x.PostId == postId).IsDeleted;

            Assert.True(result.Succeeded);
            Assert.Equal(expectedResult, actualResult);
            Assert.NotEqual(expectedDeleteStatus, actualDeleteStatus);
        }
    }
}
