using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.Openings.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Openings.Handlers.Commands
{
    public class CreateOpeningCommandHandler : IRequestHandler<CreateOpeningCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOpeningCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponses> Handle(CreateOpeningCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var opening = request.CreateOpening.ToEntity();

            opening = await _unitOfWork.OpeningRepository.Add(opening, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = opening.Id.ToString();

            return response;
        }
    }
}
