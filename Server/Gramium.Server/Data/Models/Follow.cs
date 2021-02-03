using System;
using System.ComponentModel.DataAnnotations;
using Gramium.Server.Data.Models.Base;

namespace Gramium.Server.Data.Models
{
    public class Follow : DeletableEntity<int>
    {
        [Required]
        public string UserId { get; set; }
        
        public ApplicationUser User { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public ApplicationUser Follower { get; set; }

        public bool isApproved { get; set; }
    }
}
