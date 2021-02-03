using System.Threading.Tasks;
using Gramium.Server.Infrastructure.Services;

namespace Gramium.Server.Features.Likes.Services
{
    public interface ILikesService
    {
        Task<Result> Like(int postId, string userId);
        
        Task<Result> UnLike(int postId, string userId);

        Task<bool> IsLike(int postId, string userId);
    }
}
