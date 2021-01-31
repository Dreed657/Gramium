using System.Threading.Tasks;
using Gramium.Server.Features.Profiles.Models;

namespace Gramium.Server.Features.Profiles.Services
{
    public interface IProfileService
    {
        Task<UserViewModel> GetUser(string userId);
    }
}
