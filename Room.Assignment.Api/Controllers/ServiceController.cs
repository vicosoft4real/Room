using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Room.Assignment.Application.Features.Services.Query;
using System.Threading.Tasks;
using Room.Assignment.Api.Response;
using Room.Assignment.Application.Features.Services.Command;

namespace Room.Assignment.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Searches the services.
        /// </summary>
        /// <param name="search">The search.</param>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        [ResponseCache(NoStore = true)]
        [HttpGet("search")]
        [ProducesResponseType(typeof(Responses<List<ServiceVm>>), 200)]
        public async Task<IActionResult> SearchServices([FromQuery] string search, [FromQuery] int page, [FromQuery] int size)
        {
            var response = await mediator.Send(new GetServiceListQuery { Search = search, Page = page, Size = size });


            return Ok(response.ToResponse());
        }


        /// <summary>
        /// Activates the service bonus.
        /// </summary>
        /// <param name="activatePromo">The activate promo.</param>
        /// <returns></returns>
        [HttpPost("activate")]
        [ProducesResponseType(typeof(Responses<string>), 200)]
        [ProducesResponseType(typeof(Responses<string>), 400)]
        public async Task<IActionResult> ActivateBonus([FromBody] ActivatePromoCodeCommand activatePromo)
        {
            (bool succeed, string message, string[] validationError) = await mediator.Send(activatePromo);

            if (succeed)
                return Ok(message.ToResponse(message, validationError));
            return BadRequest(message.ToResponse(message, validationError));

        }
    }
}
