using System;

namespace Gramium.Server.Data.Models.Base
{
    public class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
