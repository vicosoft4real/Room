using System.Threading.Tasks;
using Room.Assignment.Application.Models.Authentication;

namespace Room.Assignment.Application.Contracts.Identity
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        // Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}