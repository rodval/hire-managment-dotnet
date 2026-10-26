using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.Candidates.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Candidates.Handlers.Commands
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateCandidateCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseCommandResponses> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var candidate = request.CreateCandidate.ToEntity();
            candidate.PasswordHash = _passwordHasher.Hash(request.CreateCandidate.Password ?? string.Empty);

            candidate = await _unitOfWork.CandidateRepository.Add(candidate, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = candidate.Id;

            return response;
        }
    }
}
