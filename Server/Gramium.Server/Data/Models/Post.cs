using System.Data;

namespace Gramium.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Base;

    using static Constraints.Post;
    
    public class Post : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
