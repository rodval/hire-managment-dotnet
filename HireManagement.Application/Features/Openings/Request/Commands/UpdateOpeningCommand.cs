using HireManagement.Application.DTOs.Opening;
using MediatR;

namespace HireManagement.Application.Features.Openings.Request.Commands
{
    public class UpdateOpeningCommand : IRequest
    {
        public required UpdateOpeningDto Opening { get; set; }
    }
}
