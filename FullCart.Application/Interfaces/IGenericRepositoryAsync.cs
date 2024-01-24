using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> AddAsync(T entity);
    }
}
