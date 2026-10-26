using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Request.Commands;
using HireManagement.Application.Features.Candidates.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<List<CandidateListDto>>> Get(CancellationToken cancellationToken)
        {
            var admins = await _mediator.Send(new GetCandidateListRequest(), cancellationToken);
            return Ok(admins);
        }

        [HttpGet("{candidateId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult<CandidateDto>> Get(string candidateId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetCandidateRequest { CandidateId = candidateId }, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCandidateDto candidate, CancellationToken cancellationToken)
        {
            var command = new CreateCandidateCommand { CreateCandidate = candidate };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee,Candidate")]
        public async Task<ActionResult> Put([FromBody] UpdateCandidateDto candidate, CancellationToken cancellationToken)
        {
            var command = new UpdateCandidateCommand { Candidate = candidate };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{candidateId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Delete(string candidateId, CancellationToken cancellationToken)
        {
            var command = new DeleteCandidateCommand { Id = candidateId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
