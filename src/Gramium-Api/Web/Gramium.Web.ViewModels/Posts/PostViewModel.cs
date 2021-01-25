using AutoMapper;

namespace Gramium.Web.ViewModels.Posts
{
    using System;

    using Gramium.Data.Models;
    using Gramium.Services.Mapping;
    using Gramium.Web.ViewModels.User;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>().ForMember(
                m => m.UserName,
                opt => opt.MapFrom(x => x.Creator.UserName));

        }
    }
}
