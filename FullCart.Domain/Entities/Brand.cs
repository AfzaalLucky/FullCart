using FullCart.Domain.Common;
using System;
using System.Linq;

namespace FullCart.Domain.Entities
{
    public class Brand : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set;}
    }
}
