namespace Gramium.Web.ViewModels.User
{
    using Gramium.Data.Models;
    using Gramium.Services.Mapping;

    public class ShortUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }
    }
}
