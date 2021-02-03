using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramium.Server.Features.Posts.Models
{
    public class PostListingModel
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public string ImageUrl { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public bool isLiked { get; set; }
    }
}
