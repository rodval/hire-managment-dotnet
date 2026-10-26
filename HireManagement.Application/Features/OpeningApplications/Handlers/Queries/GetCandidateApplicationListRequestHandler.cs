using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Queries
{
    public class GetCandidateApplicationListRequestHandler : IRequestHandler<GetCandidateApplicationListRequest, List<OpeningApplicationListDto>>
    {
        private readonly IOpeningApplicationRepository _repository;

        public GetCandidateApplicationListRequestHandler(IOpeningApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OpeningApplicationListDto>> Handle(GetCandidateApplicationListRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.GetCandidateApplications(request.CandidateId, cancellationToken);
            return opening.ToListDtos();
        }
    }
}
