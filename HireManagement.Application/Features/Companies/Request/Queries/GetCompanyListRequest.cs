using HireManagement.Application.DTOs.Company;
using MediatR;

namespace HireManagement.Application.Features.Companies.Request.Queries
{
    public class GetCompanyListRequest : IRequest<List<CompanyListDto>>
    {
    }
}
