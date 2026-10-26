using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Request.Commands
{
    public class CreateCandidateCommand : IRequest<BaseCommandResponses>
    {
        public required CreateCandidateDto CreateCandidate { get; set; }
    }
}
