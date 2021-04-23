using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Persistence.Repositories;

namespace Room.Assignment.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        /// <summary>
        /// Adds the persistence service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RoomAssignmentDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RoomAssignmentApplication")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IServiceRepository, ServiceRepository>();


            return services;
        }
    }
}