using System;
using System.Threading;
using System.Threading.Tasks;
using Room.Assignment.Application.Contracts.Persistence;
using Room.Assignment.Domain.Entities;

namespace Room.Assignment.Persistence.Repositories
{
    /// <summary>
    /// /
    /// </summary>
    /// <seealso>
    ///     <cref>Room.Assignment.Persistence.Repositories.AsyncRepository{Room.Assignment.Domain.Entities.Services}</cref>
    /// </seealso>
    /// <seealso cref="Room.Assignment.Application.Contracts.Persistence.IServiceRepository" />
    public class ServiceRepository : AsyncRepository<Service>, IServiceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceRepository"/> class.
        /// </summary>
        /// <param name="roomAssignmentDbContext">The room assignment database context.</param>
        public ServiceRepository(RoomAssignmentDbContext roomAssignmentDbContext) : base(roomAssignmentDbContext)
        {
        }

        /// <summary>
        /// Activates the promo code.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(bool succeed, string message)> ActivatePromoCode(string id,
            CancellationToken cancellationToken = default)
        {
            var service = await RoomAssignmentDbContext.Services.FindAsync(Guid.Parse(id));
            if (service == null) return (false, "The service cannot be found");
            service.IsActivated = true;
            await RoomAssignmentDbContext.SaveChangesAsync(cancellationToken);

            return (true, "The service has been successfully activated");
        }
    }
}