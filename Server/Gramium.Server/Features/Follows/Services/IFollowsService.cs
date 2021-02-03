using System.Threading.Tasks;
using Gramium.Server.Infrastructure.Services;

namespace Gramium.Server.Features.Follows.Services
{
    public interface IFollowsService
    {
        Task<Result> Follow(string userId, string followerId);

        Task<Result> UnFollow(string userId, string followerId);

        Task<bool> IsFollower(string userId, string followerId);
    }
}
