using System.Collections.Generic;
using Gramium.Server.Features.Posts.Models;

namespace Gramium.Server.Features.Profiles.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
