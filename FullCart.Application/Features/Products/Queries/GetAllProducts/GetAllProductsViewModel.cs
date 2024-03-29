﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
