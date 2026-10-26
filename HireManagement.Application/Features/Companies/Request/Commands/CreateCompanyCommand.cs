using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Companies.Request.Commands
{
    public class CreateCompanyCommand : IRequest<BaseCommandResponses>
    {
        public required CreateCompanyDto CreateCompany { get; set; }
    }
}
