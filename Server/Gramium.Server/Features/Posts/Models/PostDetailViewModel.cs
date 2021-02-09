using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gramium.Server.Features.Comments.Models;

namespace Gramium.Server.Features.Posts.Models
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public int CommentsCount { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        
        public int Likes { get; set; }

        public bool isLiked { get; set; }
    }
}
