using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Companies.Handlers.Queries
{
    public class GetCompanyListRequestHandler : IRequestHandler<GetCompanyListRequest, List<CompanyListDto>>
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyListRequestHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyListDto>> Handle(GetCompanyListRequest request, CancellationToken cancellationToken)
        {
            var companies = await _repository.GetAll(cancellationToken);
            return companies.ToListDtos();
        }
    }
}
