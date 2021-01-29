namespace Gramium.Services.Data.Users
{
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<T> GetUserByIdAsync<T>(string userId);
    }
}
