using FullCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Specifications
{
    public class CompareWithItemsSpecification : BaseSpecification<Compare>
    {
        public CompareWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductCompares);
        }

        public CompareWithItemsSpecification(int compareId)
            : base(p => p.Id == compareId)
        {
            AddInclude(p => p.ProductCompares);
        }
    }
}
