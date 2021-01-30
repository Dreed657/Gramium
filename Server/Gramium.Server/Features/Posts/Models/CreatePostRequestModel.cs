namespace Gramium.Server.Features.Posts.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static Data.Constraints.Post;
    
    public class CreatePostRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxContentLength)]
        public string Content { get; set; }
    }
}
