using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Request.Commands
{
    public class DeleteCompanyEmployeeCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
