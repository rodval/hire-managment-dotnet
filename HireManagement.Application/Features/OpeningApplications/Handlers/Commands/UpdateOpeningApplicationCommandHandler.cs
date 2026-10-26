using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.OpeningApplications.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Commands
{
    public class UpdateOpeningApplicationCommandHandler : IRequestHandler<UpdateOpeningApplicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOpeningApplicationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.OpeningApplicationRepository.Get(request.OpeningApplication.Id, cancellationToken);

            if (application is null)
                throw new NotFoundException(nameof(application), request.OpeningApplication.Id);

            request.OpeningApplication.ApplyTo(application);

            _unitOfWork.OpeningApplicationRepository.Update(application);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
