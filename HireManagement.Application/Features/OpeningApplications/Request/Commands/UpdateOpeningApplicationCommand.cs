using HireManagement.Application.DTOs.OpeningApplication;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Commands
{
    public class UpdateOpeningApplicationCommand : IRequest
    {
        public required UpdateOpeningApplicationDto OpeningApplication { get; set; }
    }
}
