using HireManagement.Application.DTOs.Admin;
using MediatR;

namespace HireManagement.Application.Features.Admins.Request.Queries
{
    public class GetAdminListRequest : IRequest<List<AdminApiListDto>>
    {
    }
}
