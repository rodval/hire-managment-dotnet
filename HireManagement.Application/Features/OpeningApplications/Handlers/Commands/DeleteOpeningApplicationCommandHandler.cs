using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.OpeningApplications.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Commands
{
    public class DeleteOpeningApplicationCommandHandler : IRequestHandler<DeleteOpeningApplicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOpeningApplicationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.OpeningApplicationRepository.Get(request.Id, cancellationToken);

            if (application == null)
                throw new NotFoundException(nameof(application), request.Id);

            _unitOfWork.OpeningApplicationRepository.Delete(application);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
