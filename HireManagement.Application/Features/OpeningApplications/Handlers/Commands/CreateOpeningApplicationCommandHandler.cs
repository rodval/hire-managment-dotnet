using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.OpeningApplications.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Commands
{
    public class CreateOpeningApplicationCommandHandler : IRequestHandler<CreateOpeningApplicationCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOpeningApplicationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponses> Handle(CreateOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var application = request.CreateOpeningApplication.ToEntity();

            application = await _unitOfWork.OpeningApplicationRepository.Add(application, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = application.Id.ToString();

            return response;
        }
    }
}
