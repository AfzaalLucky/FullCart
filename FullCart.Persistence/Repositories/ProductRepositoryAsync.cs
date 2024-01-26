using FullCart.Application.Interfaces.Repositories;
using FullCart.Domain.Entities;
using FullCart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FullCart.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            products = dbContext.Set<Product>();
        }
    }
}
