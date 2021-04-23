using Microsoft.EntityFrameworkCore;
using Room.Assignment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Room.Assignment.Persistence.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Room.Assignment.Application.Contracts.Persistence.IAsyncRepository{T}" />
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly RoomAssignmentDbContext RoomAssignmentDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRepository{T}"/> class.
        /// </summary>
        /// <param name="roomAssignmentDbContext">The room assignment database context.</param>
        public AsyncRepository(RoomAssignmentDbContext roomAssignmentDbContext)
        {
            this.RoomAssignmentDbContext = roomAssignmentDbContext;
        }

        /// <summary>
        /// Gets all of <seealso>
        ///     <cref>T</cref>
        /// </seealso>
        /// .
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await RoomAssignmentDbContext.Set<T>().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<IQueryable<T>> GetBy(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {

            return await Task.FromResult(RoomAssignmentDbContext.Set<T>().Where(expression));
        }

        /// <summary>
        /// Gets the <typeparam>
        ///     <name>T</name>
        /// </typeparam> by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<T> GetById(string id, CancellationToken cancellationToken = default)
        {
            return await RoomAssignmentDbContext.Set<T>().FindAsync(Guid.Parse(id), cancellationToken);
        }
    }
}
