using HireManagement.Application.DTOs.Candidate;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Request.Commands
{
    public class UpdateCandidateCommand : IRequest
    {
        public required UpdateCandidateDto Candidate { get; set; }
    }
}
