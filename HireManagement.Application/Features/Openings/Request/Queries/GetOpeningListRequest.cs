using HireManagement.Application.DTOs.Opening;
using MediatR;

namespace HireManagement.Application.Features.Openings.Request.Queries
{
    public class GetOpeningListRequest : IRequest<List<OpeningListDto>>
    {
    }
}
