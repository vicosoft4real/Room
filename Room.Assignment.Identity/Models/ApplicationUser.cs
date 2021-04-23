using Microsoft.AspNetCore.Identity;

namespace Room.Assignment.Identity.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.AspNetCore.Identity.IdentityUser</cref>
    /// </seealso>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
    }
}
