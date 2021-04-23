using System;

namespace Room.Assignment.Domain.Common
{

    /// <summary>
    /// 
    /// </summary>
    public class AuditableEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTimeOffset CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>
        /// The last modified by.
        /// </value>
        public string LastModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the last modified date.
        /// </summary>
        /// <value>
        /// The last modified date.
        /// </value>
        public DateTimeOffset LastModifiedDate { get; set; }




    }
}
