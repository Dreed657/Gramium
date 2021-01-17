namespace Gramium.Web.ViewModels.Posts
{
    using Gramium.Data.Models;
    using Gramium.Services.Mapping;
    using Gramium.Web.ViewModels.User;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ShortUserViewModel Creator { get; set; }
    }
}
