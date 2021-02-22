using Gramium.Server.Data.Models;

namespace Gramium.Server.Features.Identity.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }

        public AuthenticateViewModel User { get; set; }
    }
}
