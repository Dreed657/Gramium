using System.Collections.Generic;
using System.Threading.Tasks;
using Gramium.Server.Features.Posts.Models;
using Gramium.Server.Infrastructure.Services;

namespace Gramium.Server.Features.Posts.Services
{
    public interface IPostService
    {
        Task<int> CreateAsync(string imageUrl, string content, string userId);

        Task<Result> UpdateAsync(int id, string content, string userId);

        Task<Result> DeleteAsync(int id, string userId);

        Task<IEnumerable<PostListingModel>> ByUserAsync(string userId);

        Task<IEnumerable<PostListingModel>> GetAll();

        Task<PostDetailViewModel> DetailsAsync(int id);
    }
}
