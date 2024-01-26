using FullCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Interfaces.Repositories
{
    public interface IWishlistRepositoryAsync : IRepositoryAsync<Wishlist>
    {
        Task<Wishlist> GetByUserNameAsync(string userName);
    }
}
