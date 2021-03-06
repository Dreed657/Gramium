using System;
using Gramium.Server.Features.Identity.Models;

namespace Gramium.Server.Features.Posts.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public ShortUserViewModel User { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public bool isLiked { get; set; }
    }
}
