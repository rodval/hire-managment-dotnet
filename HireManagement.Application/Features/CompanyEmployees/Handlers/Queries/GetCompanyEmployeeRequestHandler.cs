using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Handlers.Queries
{
    public class GetCompanyEmployeeRequestHandler : IRequestHandler<GetCompanyEmployeeRequest, CompanyEmployeeDto?>
    {
        private readonly ICompanyEmployeeRepository _repository;

        public GetCompanyEmployeeRequestHandler(ICompanyEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyEmployeeDto?> Handle(GetCompanyEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _repository.Get(request.CompanyEmployeeId, cancellationToken);
            return employee.ToDto();
        }
    }
}
