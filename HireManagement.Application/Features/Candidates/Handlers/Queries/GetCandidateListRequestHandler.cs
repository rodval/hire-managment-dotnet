using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Handlers.Queries
{
    public class GetCandidateListRequestHandler : IRequestHandler<GetCandidateListRequest, List<CandidateListDto>>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateListRequestHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CandidateListDto>> Handle(GetCandidateListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAll(cancellationToken);
            return admin.ToListDtos();
        }
    }
}
