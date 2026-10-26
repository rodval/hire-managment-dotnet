using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Companies.Handlers.Queries
{
    public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, CompanyDto?>
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyRequestHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyDto?> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.Get(request.CompanyId, cancellationToken);
            return company.ToDto();
        }
    }
}
