using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Request.Commands;
using HireManagement.Application.Features.Openings.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<OpeningListDto>>> Get(CancellationToken cancellationToken)
        {
            var admins = await _mediator.Send(new GetOpeningListRequest(), cancellationToken);
            return Ok(admins);
        }

        [HttpGet("{openingId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<OpeningDto>> Get(int openingId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetOpeningRequest { OpeningId = openingId }, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateOpeningDto opening, CancellationToken cancellationToken)
        {
            var command = new CreateOpeningCommand { CreateOpening = opening };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Put([FromBody] UpdateOpeningDto opening, CancellationToken cancellationToken)
        {
            var command = new UpdateOpeningCommand { Opening = opening };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{openingId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Delete(int openingId, CancellationToken cancellationToken)
        {
            var command = new DeleteOpeningCommand { Id = openingId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
