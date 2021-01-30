using System;

namespace Gramium.Server.Data.Models.Base
{
    public interface IDeletableEntity
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
