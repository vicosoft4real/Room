using MediatR;

namespace Room.Assignment.Application.Features.Services.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivatePromoCodeCommand : IRequest<(bool succeed, string message, string[] validationError)>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
    }
}