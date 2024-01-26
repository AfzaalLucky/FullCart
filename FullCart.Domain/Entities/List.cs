using FullCart.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FullCart.Domain.Entities
{
    public class List : AuditableBaseEntity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public List<ProductList> ProductLists { get; set; } = new List<ProductList>();
    }
}
