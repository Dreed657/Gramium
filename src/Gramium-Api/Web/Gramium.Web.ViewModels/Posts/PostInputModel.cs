namespace Gramium.Web.ViewModels.Posts
{
    using Gramium.Data.Models;
    using Gramium.Services.Mapping;

    public class PostInputModel : IMapFrom<Post>
    {
        public string Content { get; set; }
    }
}
