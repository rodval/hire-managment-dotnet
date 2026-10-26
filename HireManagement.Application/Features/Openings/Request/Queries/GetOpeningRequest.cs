using HireManagement.Application.DTOs.Opening;
using MediatR;

namespace HireManagement.Application.Features.Openings.Request.Queries
{
    public class GetOpeningRequest : IRequest<OpeningDto?>
    {
        public required int OpeningId { get; set; }
    }
}
