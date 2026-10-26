using HireManagement.Application.DTOs.Company;
using MediatR;

namespace HireManagement.Application.Features.Companies.Request.Queries
{
    public class GetCompanyRequest : IRequest<CompanyDto?>
    {
        public required int CompanyId { get; set; }
    }
}
