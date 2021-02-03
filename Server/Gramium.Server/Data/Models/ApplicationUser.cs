using System;
using System.Collections.Generic;
using Gramium.Server.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Gramium.Server.Data.Models
{
    public class ApplicationUser : IdentityUser<string>, IEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Posts = new HashSet<Post>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
