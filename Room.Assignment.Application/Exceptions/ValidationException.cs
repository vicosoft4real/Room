using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Room.Assignment.Application.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class ValidationException : ApplicationException
    {
        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        public List<string> ValidationErrors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validation in validationResult.Errors)
            {
                ValidationErrors.Add(validation.ErrorMessage);
            }
        }
    }
}