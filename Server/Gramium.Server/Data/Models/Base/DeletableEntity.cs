using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramium.Server.Data.Models.Base
{
    public class DeletableEntity : Entity, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
