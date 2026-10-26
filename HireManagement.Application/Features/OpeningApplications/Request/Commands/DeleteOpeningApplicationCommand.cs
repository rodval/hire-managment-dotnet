using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Commands
{
    public class DeleteOpeningApplicationCommand : IRequest
    {
        public required int Id { get; set; }
    }
}
