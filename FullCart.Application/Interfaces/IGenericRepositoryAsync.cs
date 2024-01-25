using System;
using System.Linq;

namespace FullCart.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }
}
