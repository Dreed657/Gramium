using System;
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
    }
}
