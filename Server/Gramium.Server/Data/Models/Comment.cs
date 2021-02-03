using System.ComponentModel.DataAnnotations;
using Gramium.Server.Data.Models.Base;

namespace Gramium.Server.Data.Models
{
    public class Comment : DeletableEntity<int>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
