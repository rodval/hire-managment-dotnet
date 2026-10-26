using MediatR;

namespace HireManagement.Application.Features.Openings.Request.Commands
{
    public class DeleteOpeningCommand : IRequest
    {
        public required int Id { get; set; }
    }
}
