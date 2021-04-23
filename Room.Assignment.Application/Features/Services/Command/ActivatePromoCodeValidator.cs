using FluentValidation;

namespace Room.Assignment.Application.Features.Services.Command
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso>
    ///     <cref>FluentValidation.AbstractValidator{Room.Assignment.Application.Features.Services.Command.ActivatePromoCodeCommand}</cref>
    /// </seealso>
    public class ActivatePromoCodeValidator : AbstractValidator<ActivatePromoCodeCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivatePromoCodeValidator"/> class.
        /// </summary>
        public ActivatePromoCodeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{propertyName} is required");


        }
    }
}