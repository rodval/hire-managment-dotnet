using HireManagement.Application.DTOs.Candidate;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Request.Queries
{
    public class GetCandidateRequest : IRequest<CandidateDto?>
    {
        public required string CandidateId { get; set; }
    }
}
