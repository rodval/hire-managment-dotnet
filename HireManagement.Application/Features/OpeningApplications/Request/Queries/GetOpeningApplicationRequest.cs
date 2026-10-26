using HireManagement.Application.DTOs.OpeningApplication;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Queries
{
    public class GetOpeningApplicationRequest : IRequest<OpeningApplicationDto?>
    {
        public required int OpeningApplicationId { get; set; }
    }
}
