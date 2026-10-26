using HireManagement.Application.DTOs.CompanyEmployee;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Request.Queries
{
    public class GetCompanyEmployeeListRequest : IRequest<List<CompanyEmployeeListDto>>
    {
    }
}
