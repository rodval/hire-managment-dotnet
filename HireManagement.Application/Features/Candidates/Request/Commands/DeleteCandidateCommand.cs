using MediatR;

namespace HireManagement.Application.Features.Candidates.Request.Commands
{
    public class DeleteCandidateCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
