using FullCart.Domain.Entities;
using System;
using System.Linq;

namespace FullCart.Application.Interfaces.Repositories
{
    public interface ICartRepositoryAsync : IRepositoryAsync<Cart>
    {
        Task<Cart> GetByUserNameAsync(string userName);
    }
}
