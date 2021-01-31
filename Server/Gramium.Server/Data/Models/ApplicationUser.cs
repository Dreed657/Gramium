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
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Post> Posts { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
