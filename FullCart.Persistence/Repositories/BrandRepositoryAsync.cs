using FullCart.Application.Interfaces.Repositories;
using FullCart.Domain.Entities;
using FullCart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Persistence.Repositories
{
    public class BrandRepositoryAsync : GenericRepositoryAsync<Brand>, IBrandRepositoryAsync
    {
        private readonly DbSet<Brand> brands;

        public BrandRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            brands = dbContext.Set<Brand>();
        }
    }
}
