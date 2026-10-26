using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Handlers.Queries
{
    public class GetCompanyEmployeeListRequestHandler : IRequestHandler<GetCompanyEmployeeListRequest, List<CompanyEmployeeListDto>>
    {
        private readonly ICompanyEmployeeRepository _repository;

        public GetCompanyEmployeeListRequestHandler(ICompanyEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyEmployeeListDto>> Handle(GetCompanyEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetAll(cancellationToken);
            return employee.ToListDtos();
        }
    }
}
