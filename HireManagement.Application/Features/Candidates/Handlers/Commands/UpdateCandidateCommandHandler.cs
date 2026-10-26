using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Candidates.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Handlers.Commands
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCandidateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _unitOfWork.CandidateRepository.Get(request.Candidate.Id ?? string.Empty, cancellationToken);

            if (candidate is null)
                throw new NotFoundException(nameof(candidate), request.Candidate.Id);

            request.Candidate.ApplyTo(candidate);

            _unitOfWork.CandidateRepository.Update(candidate);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
