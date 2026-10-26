using HireManagement.Application.DTOs.Admin;
using MediatR;

namespace HireManagement.Application.Features.Admins.Request.Queries
{
    public class GetAdminRequest : IRequest<AdminApiDto?>
    {
        public required string AdminId { get; set; }
    }
}
