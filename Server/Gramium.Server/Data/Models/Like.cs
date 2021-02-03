using System;
using System.ComponentModel.DataAnnotations;
using Gramium.Server.Data.Models.Base;

namespace Gramium.Server.Data.Models
{
    public class Like : DeletableEntity<int>
    {
        [Required]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
