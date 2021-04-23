﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Room.Assignment.Application.Contracts.Identity;
using Room.Assignment.Application.Models.Authentication;

namespace Room.Assignment.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticates the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await authenticationService.AuthenticateAsync(request));
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        //{
        //    return Ok(await _authenticationService.RegisterAsync(request));
        //}
    }
}
