using Gramium.Server.Features.Identity.Models;
using System.Threading.Tasks;

namespace Gramium.Server.Features.Identity.Services
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
