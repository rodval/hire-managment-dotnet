using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Request.Commands;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpeningApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<List<OpeningApplicationListDto>>> Get(CancellationToken cancellationToken)
        {
            var admins = await _mediator.Send(new GetOpeningApplicationListRequest(), cancellationToken);
            return Ok(admins);
        }

        [HttpGet("{applicationId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<OpeningApplicationDto>> Get(int applicationId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetOpeningApplicationRequest { OpeningApplicationId = applicationId }, cancellationToken);
            return Ok(admin);
        }

        [HttpGet("candidates/{candidateId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult<List<OpeningApplicationListDto>>> GetCandidateApplications(string candidateId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetCandidateApplicationListRequest { CandidateId = candidateId }, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateOpeningApplicationDto application, CancellationToken cancellationToken)
        {
            var command = new CreateOpeningApplicationCommand { CreateOpeningApplication = application };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Put([FromBody] UpdateOpeningApplicationDto application, CancellationToken cancellationToken)
        {
            var command = new UpdateOpeningApplicationCommand { OpeningApplication = application };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{applicationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Delete(int applicationId, CancellationToken cancellationToken)
        {
            var command = new DeleteOpeningApplicationCommand { Id = applicationId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
