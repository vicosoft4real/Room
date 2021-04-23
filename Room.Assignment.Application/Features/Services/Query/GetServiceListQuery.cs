using MediatR;
using System.Collections.Generic;

namespace Room.Assignment.Application.Features.Services.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>IRequest{List{ServiceVm}}</cref>
    /// </seealso>
    public class GetServiceListQuery : IRequest<List<ServiceVm>>
    {
        /// <summary>
        /// Gets or sets the search.
        /// </summary>
        /// <value>
        /// The search.
        /// </value>
        public string Search { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; set; }
    }
}
