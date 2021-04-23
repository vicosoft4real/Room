using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Room.Assignment.Identity.Models;

namespace Room.Assignment.Identity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{Room.Assignment.Identity.Models.ApplicationUser}</cref>
    /// </seealso>
    public class RoomAssignmentIdentityContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomAssignmentIdentityContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public RoomAssignmentIdentityContext(DbContextOptions<RoomAssignmentIdentityContext> options) : base(options)
        {

        }
    }
}