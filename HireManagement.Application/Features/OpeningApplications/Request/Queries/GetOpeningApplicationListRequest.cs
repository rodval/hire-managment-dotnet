using HireManagement.Application.DTOs.OpeningApplication;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Queries
{
    public class GetOpeningApplicationListRequest : IRequest<List<OpeningApplicationListDto>>
    {
    }
}
