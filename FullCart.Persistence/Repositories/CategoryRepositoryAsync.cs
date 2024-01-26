using FullCart.Application.Interfaces.Repositories;
using FullCart.Domain.Entities;
using FullCart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FullCart.Persistence.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        private readonly DbSet<Category> categories;

        public CategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            categories = dbContext.Set<Category>();
        }
    }
}
