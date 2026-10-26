using HireManagement.Application.DTOs.CompanyEmployee;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Request.Commands
{
    public class UpdateCompanyEmployeeCommand : IRequest
    {
        public required UpdateCompanyEmployeeDto Employee { get; set; }
    }
}
