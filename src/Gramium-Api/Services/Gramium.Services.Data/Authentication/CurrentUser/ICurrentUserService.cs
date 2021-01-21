namespace Gramium.Services.Data.Authentication.CurrentUser
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}
