using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Domain.Entities
{
    public class ProductCompare
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CompareId { get; set; }
        public Compare Compare { get; set; }
    }
}
