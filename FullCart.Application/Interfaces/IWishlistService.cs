using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Interfaces
{
    public interface IWishlistService
    {
        //Task<WishlistModel> GetWishlistByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int wishlistId, int productId);
    }
}
