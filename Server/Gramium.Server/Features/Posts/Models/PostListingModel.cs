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
    }
}
