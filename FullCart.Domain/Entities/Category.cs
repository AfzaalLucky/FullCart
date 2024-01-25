using FullCart.Domain.Common;
using System;
using System.Linq;

namespace FullCart.Domain.Entities
{
    public class Category : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
