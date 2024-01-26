using FullCart.Domain.Common;

namespace FullCart.Domain.Entities
{
    public class Specification : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
