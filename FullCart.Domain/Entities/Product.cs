﻿using FullCart.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }

        // Navigation Properties
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}
