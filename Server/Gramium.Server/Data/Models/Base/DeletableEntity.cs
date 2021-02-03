using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramium.Server.Data.Models.Base
{
    public abstract class DeletableEntity<TKey> : Entity<TKey>, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
