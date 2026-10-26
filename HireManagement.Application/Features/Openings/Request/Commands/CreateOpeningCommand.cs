using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Openings.Request.Commands
{
    public class CreateOpeningCommand : IRequest<BaseCommandResponses>
    {
        public required CreateOpeningDto CreateOpening { get; set; }
    }
}
