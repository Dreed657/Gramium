using System;
using System.ComponentModel.DataAnnotations;
using Gramium.Server.Data.Models.Base;
using Gramium.Server.Data.Models.Enums;

namespace Gramium.Server.Data.Models
{
    public class Profile : IEntity
    {
        [Key]
        [Required]
        public string userId { get; set; }

        public ApplicationUser User { get; set; }

        public string ProfileImage { get; set; }

        public Gender Gender { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime? ModifiedOn { get; set; }
    }
}
