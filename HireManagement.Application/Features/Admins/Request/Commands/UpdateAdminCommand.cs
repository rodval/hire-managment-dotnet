using HireManagement.Application.DTOs.Admin;
using MediatR;

namespace HireManagement.Application.Features.Admins.Request.Commands
{
    public class UpdateAdminCommand : IRequest
    {
        public required UpdateAdminApiDto AdminApi { get; set; }
    }
}
