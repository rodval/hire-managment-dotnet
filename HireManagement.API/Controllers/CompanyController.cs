using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Request.Commands;
using HireManagement.Application.Features.Companies.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyListDto>>> Get(CancellationToken cancellationToken)
        {
            var admins = await _mediator.Send(new GetCompanyListRequest(), cancellationToken);
            return Ok(admins);
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> Get(int companyId, CancellationToken cancellationToken)
        {
            var admin = await _mediator.Send(new GetCompanyRequest { CompanyId = companyId }, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCompanyDto company, CancellationToken cancellationToken)
        {
            var command = new CreateCompanyCommand { CreateCompany = company };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateCompanyDto company, CancellationToken cancellationToken)
        {
            var command = new UpdateCompanyCommand { Company = company };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{companyId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int companyId, CancellationToken cancellationToken)
        {
            var command = new DeleteCompanyCommand { Id = companyId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
