﻿using FullCart.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Domain.Entities
{
    public class Compare : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<ProductCompare> ProductCompares { get; set; } = new List<ProductCompare>();

        public void AddItem(int productId)
        {
            var existingItem = ProductCompares.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
                return;

            ProductCompares.Add(new ProductCompare
            {
                ProductId = productId,
                CompareId = this.Id
            });
        }

        public void RemoveItem(int productId)
        {
            var removedItem = ProductCompares.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                ProductCompares.Remove(removedItem);
            }
        }
    }
}
