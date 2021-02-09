using System;
using System.Collections.Generic;
using System.ComponentModel;
using Gramium.Server.Data.Models.Base;
using Gramium.Server.Data.Models.Enums;
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
            this.Followers = new HashSet<Follow>();
            this.Following = new HashSet<Follow>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImage { get; set; }

        [DefaultValue(Enums.Gender.Other)]
        public Gender Gender { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Follow> Followers { get; set; }

        public ICollection<Follow> Following { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
