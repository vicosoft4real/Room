using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Room.Assignment.Application.Contracts.Persistence;

namespace Room.Assignment.Application.Features.Services.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         MediatR.IRequestHandler{Room.Assignment.Application.Features.Services.Command.ActivatePromoCodeCommand,
    ///         (System.Boolean succeed, System.String message, System.String[] validationError)}
    ///     </cref>
    /// </seealso>
    public class ActivatePromoCodeCommandHandler : IRequestHandler<ActivatePromoCodeCommand, (bool succeed, string message, string[] validationError)>
    {
        private readonly IServiceRepository serviceRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="ActivatePromoCodeCommandHandler"/> class.
        /// </summary>
        /// <param name="serviceRepository">The service repository.</param>
        public ActivatePromoCodeCommandHandler(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;

        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool succeed, string message, string[] validationError)> Handle(ActivatePromoCodeCommand request, CancellationToken cancellationToken)
        {
            var validator = new ActivatePromoCodeValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                (bool succeed, string message) = await serviceRepository.ActivatePromoCode(request.Id, cancellationToken);
                if (succeed)
                {
                    return (true, message, null);
                }

                return (false, message, null);
            }

            return (false, "Request validation failed",
                validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
        }
    }
}