using FullCart.Domain.Common;
using System;
using System.Linq;

namespace FullCart.Domain.Entities
{
    public class OrderItem : AuditableBaseEntity

    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
