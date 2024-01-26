using System;
using System.Linq;

namespace FullCart.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public string? LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedOn { get; set; }

    }
}
