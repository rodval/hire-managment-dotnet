using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Queries
{
    public class GetOpeningApplicationListRequestHandler : IRequestHandler<GetOpeningApplicationListRequest, List<OpeningApplicationListDto>>
    {
        private readonly IOpeningApplicationRepository _repository;

        public GetOpeningApplicationListRequestHandler(IOpeningApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OpeningApplicationListDto>> Handle(GetOpeningApplicationListRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.GetAll(cancellationToken);
            return opening.ToListDtos();
        }
    }
}
