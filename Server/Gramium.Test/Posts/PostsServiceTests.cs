using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Posts.Services;
using Gramium.Server.Infrastructure.Services;
using Gramium.Test.Base;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Gramium.Test.Posts
{
    public class PostsServiceTests : TestBase
    {
        [Fact]
        public async Task CreatePostShouldWorkCorrectly()
        {
            var db = GetDatabase();
            var service = new PostService(db, null);
            
            int expected = db.Posts.Count() + 1;
            await service.CreateAsync("string", "string", Guid.NewGuid().ToString());
            var actual = db.Posts.Count();
            
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async Task UpdatePostShouldWorkCorrectly()
        {
            var userId = Guid.NewGuid().ToString();
            
            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = 1, Content = "string", UserId = userId });
            await db.SaveChangesAsync();
            
            var service = new PostService(db, null);

            var expectedPost = await db.Posts.FirstOrDefaultAsync(x => x.Id == 1);
            await service.UpdateAsync(1, "updated content", userId);
            var actualPost = await db.Posts.FirstOrDefaultAsync(x => x.Id == 1);

            Assert.Equal(expectedPost.Content, actualPost.Content);
        }

        [Fact]
        public async Task UpdatePostShouldReturnAnErrorWhenPostNotFound()
        {
            var userId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            var service = new PostService(db, null);

            var actualResult = await service.UpdateAsync(1, "updated content", userId);

            string expectedError = "This user cannot update this post.";

            Assert.Equal(expectedError, actualResult.Error);
        }

        [Fact]
        public async Task DeletePostShouldWorkCorrectly()
        {
            var userId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = 1, Content = "string", UserId = userId });
            await db.SaveChangesAsync();

            var service = new PostService(db, null);

            var post = await db.Posts.FirstOrDefaultAsync(x => x.Id == 1);
            
            var expected = post.IsDeleted;
            await service.DeleteAsync(1, userId);
            var actual = post.IsDeleted;

            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public async Task DeletePostShouldReturnAnErrorWhenPostNotFound()
        {
            var userId = Guid.NewGuid().ToString();
            
            var db = GetDatabase();
            var service = new PostService(db, null);

            var actualResult = await service.DeleteAsync(1,  userId);

            string expectedError = "This user cannot delete this post.";

            Assert.Equal(expectedError, actualResult.Error);
        }
    }
}
