using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Commands
{
    public class CreateOpeningApplicationCommand : IRequest<BaseCommandResponses>
    {
        public required CreateOpeningApplicationDto CreateOpeningApplication { get; set; }
    }
}
