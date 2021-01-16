namespace Gramium.Services.Authentication
{
    using System.Threading.Tasks;

    using Gramium.Web.ViewModels.Auth;

    public interface IAuthService
    {
        Task<string> AuthenticateUserAsync(UserLoginModel model, string jwtSecret);

        Task<bool> RegisterUser(UserRegisterModel model);
    }
}
