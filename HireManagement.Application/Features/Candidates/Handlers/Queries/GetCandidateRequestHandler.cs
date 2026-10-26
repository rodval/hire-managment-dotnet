using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Handlers.Queries
{
    public class GetCandidateRequestHandler : IRequestHandler<GetCandidateRequest, CandidateDto?>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateRequestHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<CandidateDto?> Handle(GetCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.Get(request.CandidateId, cancellationToken);
            return candidate.ToDto();
        }
    }
}
