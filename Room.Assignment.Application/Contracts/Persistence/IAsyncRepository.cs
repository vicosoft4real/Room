using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Room.Assignment.Application.Contracts.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the by expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IQueryable<T>> GetBy(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<T> GetById(string id, CancellationToken cancellationToken = default);
    }
}
