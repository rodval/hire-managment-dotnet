using HireManagement.Application.DTOs.Candidate;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Request.Queries
{
    public class GetCandidateListRequest : IRequest<List<CandidateListDto>>
    {
    }
}
