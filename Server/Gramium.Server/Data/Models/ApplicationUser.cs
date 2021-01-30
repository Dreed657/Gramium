using System;
using Gramium.Server.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace Gramium.Server.Data.Models
{
    public class ApplicationUser : IdentityUser<string>, IEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
