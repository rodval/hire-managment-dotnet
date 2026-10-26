using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Candidates.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Handlers.Commands
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCandidateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _unitOfWork.CandidateRepository.Get(request.Id, cancellationToken);

            if (candidate == null)
                throw new NotFoundException(nameof(candidate), request.Id);

            _unitOfWork.CandidateRepository.Delete(candidate);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
