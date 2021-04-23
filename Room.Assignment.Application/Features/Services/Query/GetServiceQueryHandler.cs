

using AutoMapper;
using MediatR;
using Room.Assignment.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Room.Assignment.Application.Features.Services.Query
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>IRequestHandler{GetServiceListQuery, List{ServiceVm}}</cref>
    /// </seealso>
    public class GetServiceQueryHandler : IRequestHandler<GetServiceListQuery, List<ServiceVm>>
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServiceQueryHandler"/> class.
        /// </summary>
        /// <param name="serviceRepository">The service repository.</param>
        /// <param name="mapper">The mapper.</param>
        public GetServiceQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            this.serviceRepository = serviceRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles a request for the service
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        /// <exception cref="ArgumentNullException">Request cannot be null</exception>
        public async Task<List<ServiceVm>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
        {
            // todo this should be from configuration
            int defaultPageSize = request.Size == 0 ? 100 : request.Size;
            int defaultPage = request.Page == 0 ? 1 : request.Page;

            var services = await serviceRepository.GetBy(x =>
                x.Name.ToLower().Contains(request.Search.ToLower()) || (string.IsNullOrEmpty(request.Search)), cancellationToken);
            var pageResult = services
                .Skip((defaultPage - 1) * defaultPageSize).
                Take(defaultPageSize)
                .OrderBy(x => x.Name)
                .ToList();
            return mapper.Map<List<ServiceVm>>(pageResult);

        }
    }
}
