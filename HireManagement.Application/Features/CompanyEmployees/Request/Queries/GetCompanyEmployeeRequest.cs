using HireManagement.Application.DTOs.CompanyEmployee;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Request.Queries
{
    public class GetCompanyEmployeeRequest : IRequest<CompanyEmployeeDto?>
    {
        public required string CompanyEmployeeId { get; set; }
    }
}
