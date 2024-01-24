using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
