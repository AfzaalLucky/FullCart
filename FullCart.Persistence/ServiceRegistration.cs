using FullCart.Application.Interfaces;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Persistence.Contexts;
using FullCart.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullCart.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IBrandRepositoryAsync, BrandRepositoryAsync>();
            #endregion
        }
    }
}