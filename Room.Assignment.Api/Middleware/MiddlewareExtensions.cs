using Microsoft.AspNetCore.Builder;

namespace Room.Assignment.Api.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Uses the custom exception handler.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}