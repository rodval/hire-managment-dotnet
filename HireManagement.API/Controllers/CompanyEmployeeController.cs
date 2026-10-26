using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Request.Commands;
using HireManagement.Application.Features.CompanyEmployees.Request.Queries;
using HireManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyEmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyEmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<CompanyEmployeeListDto>>> Get(CancellationToken cancellationToken)
        {
            var employee = await _mediator.Send(new GetCompanyEmployeeListRequest(), cancellationToken);
            return Ok(employee);
        }

        [HttpGet("{employeeId}")]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult<CompanyEmployeeDto>> Get(string employeeId, CancellationToken cancellationToken)
        {
            var employee = await _mediator.Send(new GetCompanyEmployeeRequest { CompanyEmployeeId = employeeId }, cancellationToken);
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponses>> Post([FromBody] CreateCompanyEmployeeDto employee, CancellationToken cancellationToken)
        {
            var command = new CreateCompanyEmployeeCommand { CreateEmployee = employee };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator,CompanyAdmin,Employee")]
        public async Task<ActionResult> Put([FromBody] UpdateCompanyEmployeeDto employee, CancellationToken cancellationToken)
        {
            var command = new UpdateCompanyEmployeeCommand { Employee = employee };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string employeeId, CancellationToken cancellationToken)
        {
            var command = new DeleteCompanyEmployeeCommand { Id = employeeId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
