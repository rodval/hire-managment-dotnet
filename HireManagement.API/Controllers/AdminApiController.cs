using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Request.Commands;
using HireManagement.Application.Features.Admins.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminApiListDto>>> Get(CancellationToken cancellationToken)
        {
            var admins = await _mediator.Send(new GetAdminListRequest(), cancellationToken);
            return Ok(admins);
        }

        [HttpGet("{adminId}")]
        public async Task<ActionResult<AdminApiDto>> Get(string adminId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetAdminRequest { AdminId = adminId }, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateAdminApiDto admin, CancellationToken cancellationToken)
        {
            var command = new CreateAdminCommand { CreateAdminApi = admin };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateAdminApiDto admin, CancellationToken cancellationToken)
        {
            var command = new UpdateAdminCommand { AdminApi = admin };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{adminId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string adminId, CancellationToken cancellationToken)
        {
            var command = new DeleteAdminCommand { Id = adminId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}

