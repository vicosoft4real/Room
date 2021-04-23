using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Room.Assignment.Application
{
    /// <summary>
    /// Extension method for registering Application
    /// </summary>
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Adds the application to service collection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
