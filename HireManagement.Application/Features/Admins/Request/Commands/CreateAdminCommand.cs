using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Admins.Request.Commands
{
    public class CreateAdminCommand : IRequest<BaseCommandResponses>
    {
        public required CreateAdminApiDto CreateAdminApi { get; set; }
    }
}
