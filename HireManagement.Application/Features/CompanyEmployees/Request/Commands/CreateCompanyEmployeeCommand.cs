using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Request.Commands
{
    public class CreateCompanyEmployeeCommand : IRequest<BaseCommandResponses>
    {
        public required CreateCompanyEmployeeDto CreateEmployee { get; set; }
    }
}
