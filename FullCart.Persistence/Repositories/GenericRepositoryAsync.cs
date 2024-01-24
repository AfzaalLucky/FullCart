using FullCart.Application.Interfaces;
using FullCart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
