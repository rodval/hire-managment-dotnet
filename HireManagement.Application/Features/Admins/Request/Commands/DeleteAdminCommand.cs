using MediatR;

namespace HireManagement.Application.Features.Admins.Request.Commands
{
    public class DeleteAdminCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
