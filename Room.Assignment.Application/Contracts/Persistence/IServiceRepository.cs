using System.Threading;
using System.Threading.Tasks;
using Room.Assignment.Domain.Entities;

namespace Room.Assignment.Application.Contracts.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Room.Assignment.Application.Contracts.Persistence.IAsyncRepository{Room.Assignment.Domain.Entities.Services}</cref>
    /// </seealso>
    public interface IServiceRepository : IAsyncRepository<Service>
    {
        /// <summary>
        /// Activates the promo code.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(bool succeed, string message)> ActivatePromoCode(string id, CancellationToken cancellationToken = default);
    }
}
