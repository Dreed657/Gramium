using System.Collections.Generic;
using System.Data;

namespace Gramium.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Base;

    using static Constraints.Post;
    
    public class Post : DeletableEntity<int>
    {
        public Post()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }
            
        [Required]
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
