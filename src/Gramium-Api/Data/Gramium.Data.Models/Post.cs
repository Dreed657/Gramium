namespace Gramium.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Gramium.Data.Common.Models;

    public class Post : BaseModel<int>
    {
        public int id;

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
    }
}
