using System.Collections.Generic;
using Gramium.Server.Data.Models.Enums;
using Gramium.Server.Features.Posts.Models;

namespace Gramium.Server.Features.Profiles.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Gender Gender { get; set; }

        public string ProfileImageUrl { get; set; }

        public int PostsCount { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public bool? IsFollowing { get; set; }
    }
}
