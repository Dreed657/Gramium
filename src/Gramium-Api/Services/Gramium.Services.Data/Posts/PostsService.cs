namespace Gramium.Services.Data.Posts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Gramium.Data.Common.Repositories;
    using Gramium.Data.Models;
    using Gramium.Services.Mapping;
    using Gramium.Web.ViewModels.Posts;
    using Microsoft.EntityFrameworkCore;

    public class PostsService : IPostsService
    {
        private readonly IRepository<Post> postRepo;
        private readonly IMapper mapper;

        public PostsService(IRepository<Post> postRepo, IMapper mapper)
        {
            this.postRepo = postRepo;
            this.mapper = mapper;
        }

        public async Task<T> CreateAsync<T>(PostInputModel model)
        {
            var post = new Post()
            {
                Content = model.Content,
            };

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();

            return this.mapper.Map<T>(post);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await this.postRepo.All().FirstOrDefaultAsync(x => x.id == id);

            if (post == null)
            {
                return false;
            }

            // TODO: CHANGE POST MODEL TO BE DELETABLE
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.postRepo.All().To<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByUserIdAsync<T>(string userId)
        {
            return await this.postRepo.All().Where(x => x.CreatorId == userId).To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            return await this.postRepo.All().Where(x => x.id == id).To<T>().FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(PostInputModel model, int id)
        {
            var post = await this.postRepo.All().FirstOrDefaultAsync(x => x.id == id);

            if (post == null)
            {
                return false;
            }

            post.Content = model.Content;

            this.postRepo.Update(post);
            await this.postRepo.SaveChangesAsync();

            return true;
        }
    }
}
