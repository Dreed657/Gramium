using System;

namespace Gramium.Server.Data.Models.Base
{
    public abstract class Entity<TKey> : IEntity
    {
        public TKey Id { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
