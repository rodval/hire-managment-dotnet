using HireManagement.Application.DTOs.Company;
using MediatR;

namespace HireManagement.Application.Features.Companies.Request.Commands
{
    public class UpdateCompanyCommand : IRequest
    {
        public required UpdateCompanyDto Company { get; set; }
    }
}
