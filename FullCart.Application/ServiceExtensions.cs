using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace FullCart.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
