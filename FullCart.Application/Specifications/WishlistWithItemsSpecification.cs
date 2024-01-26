using FullCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Specifications
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductWishlists);
        }

        public WishlistWithItemsSpecification(int wishlistId)
            : base(p => p.Id == wishlistId)
        {
            AddInclude(p => p.ProductWishlists);
        }
    }
}
