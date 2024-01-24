using FullCart.Application;
using FullCart.Infrastructure;
using FullCart.Persistence;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FullCart.API.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        private IConfiguration configuration { get; }

        public ServiceRegistration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddInfrastructureLayer(configuration);
            services.AddPersistenceLayer(configuration);
        }
    }
}
