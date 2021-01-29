namespace Gramium.Web.ViewModels.User
{
    using System.Collections.Generic;

    using Gramium.Data.Models;
    using Gramium.Services.Mapping;
    using Gramium.Web.ViewModels.Posts;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
