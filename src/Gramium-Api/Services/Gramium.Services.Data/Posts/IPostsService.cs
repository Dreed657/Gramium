namespace Gramium.Services.Data.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Gramium.Data.Models;
    using Gramium.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<T> CreateAsync<T>(PostInputModel model, string userId);

        Task<bool> UpdateAsync(PostInputModel model, int id);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllByUserIdAsync<T>(string userId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetByIdAsync<T>(int id);
    }
}
