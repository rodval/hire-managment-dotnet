using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Openings.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.Openings.Handlers.Commands
{
    public class DeleteOpeningCommandHandler : IRequestHandler<DeleteOpeningCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOpeningCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOpeningCommand request, CancellationToken cancellationToken)
        {
            var opening = await _unitOfWork.OpeningRepository.Get(request.Id, cancellationToken);

            if (opening == null)
                throw new NotFoundException(nameof(opening), request.Id);

            _unitOfWork.OpeningRepository.Delete(opening);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
