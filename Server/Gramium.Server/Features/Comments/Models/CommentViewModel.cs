using System;

namespace Gramium.Server.Features.Comments.Models
{
    public class CommentViewModel
    {
        public string UserName { get; set; }
        
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
