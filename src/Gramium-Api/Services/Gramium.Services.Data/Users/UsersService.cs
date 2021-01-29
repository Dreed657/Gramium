namespace Gramium.Services.Data.Users
{
    using System.Linq;
    using System.Threading.Tasks;

    using Gramium.Data.Common.Repositories;
    using Gramium.Data.Models;
    using Gramium.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationUser> userRepo;

        public UsersService(IRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<T> GetUserByIdAsync<T>(string userId)
        {
            return await this.userRepo.All().Where(x => x.Id == userId).To<T>().FirstOrDefaultAsync();
        }
    }
}
