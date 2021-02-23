using System;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Data.Models;
using Gramium.Server.Features.Comments.Models;
using Gramium.Server.Features.Comments.Services;
using Gramium.Test.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Gramium.Test.Comments
{
    public class CommentsServiceTests : TestBase
    {
        [Fact]
        public async Task CreateShouldWorkCorrectly()
        {
            var userId = Guid.NewGuid().ToString();
            
            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() {Id = userId});
            await db.Posts.AddAsync(new Post(){Id = 1, Content = "string", UserId = userId});
            await db.SaveChangesAsync();

            var service = new CommentsService(db);

            var model = new CreateCommentInputModel()
            {
                postId = 1,
                Content = "comment string",
            };

            var post = await db.Posts.FirstOrDefaultAsync(x => x.Id == 1);

            var expectedResult = post.Comments.Count + 1;
            var result = await service.Create(model, userId);
            var actualResult = post.Comments.Count;
            
            Assert.Equal(expectedResult, actualResult);
        }

        // TODO: FIX TEST
        //[Fact]
        //public async Task CreateShouldReturnAnErrorIfUserDoesNotExists()
        //{
        //    var userId = Guid.NewGuid().ToString();

        //    var db = GetDatabase();
        //    var service = new CommentsService(db);

        //    var actualResult = await service.Create(null, userId);

        //    string expectedResult = "User does not exists!";

        //    Assert.Equal(expectedResult, actualResult.Error);
        //}

        // TODO: FIX TEST
        //[Fact]
        //public async Task CreateShouldReturnAnErrorIfPostDoesNotExists()
        //{
        //    var userId = Guid.NewGuid().ToString();

        //    var db = GetDatabase();
        //    await db.Users.AddAsync(new ApplicationUser() {Id = userId});
        //    await db.SaveChangesAsync();
            
        //    var service = new CommentsService(db);

        //    var model = new CreateCommentInputModel()
        //    {
        //        postId = 1,
        //    };

        //    var actualResult = await service.Create(model, userId);

        //    string expectedResult = "Post does not exists!";

        //    Assert.Equal(expectedResult, actualResult.Error);
        //}

        [Fact]
        public async Task UpdateShouldWorkCorrectly()
        {
            var userId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = 1, Content = "string", UserId = userId });
            await db.Comments.AddAsync(new Comment() { Id = 1, Content = "string", UserId = userId, PostId = 1 });
            await db.SaveChangesAsync();

            var service = new CommentsService(db);
            
            var expectedResult = "comment string";
            var model = new UpdateCommentInputModel()
            {
                Content = expectedResult,
            };

            var comment = await db.Comments.FirstOrDefaultAsync(x => x.Id == 1);
            
            var result = await service.Update(1, model);

            var actualResult = comment.Content;
            
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task UpdateShouldReturnAnErrorIfCommentNotFound()
        {
            var userId = Guid.NewGuid().ToString();

            var db = GetDatabase();

            var service = new CommentsService(db);

            var result = await service.Update(1, null);

            var expectedResult = "Comment with this ID cannot be found!";

            Assert.Equal(expectedResult, result.Error);
        }

        [Fact]
        public async Task DeleteShouldWorkCorrectly()
        {
            var userId = Guid.NewGuid().ToString();

            var db = GetDatabase();
            await db.Users.AddAsync(new ApplicationUser() { Id = userId });
            await db.Posts.AddAsync(new Post() { Id = 1, Content = "string", UserId = userId });
            await db.Comments.AddAsync(new Comment() { Id = 1, Content = "string", UserId = userId, PostId = 1});
            await db.SaveChangesAsync();

            var service = new CommentsService(db);

            var expectedResult = db.Comments.Count(x => !x.IsDeleted) - 1;

            var result = await service.Delete(1);

            var actualResult = db.Comments.Count(x => !x.IsDeleted);

            Assert.Equal(expectedResult, actualResult);
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteShouldReturnFalseIfCommentNotFound()
        {
            var db = GetDatabase();

            var service = new CommentsService(db);

            var result = await service.Delete(1);

            Assert.False(result);
        }
    }
}
