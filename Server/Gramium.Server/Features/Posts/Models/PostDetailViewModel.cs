using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramium.Server.Features.Posts.Models
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }
    }
}
