using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Companies.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.Companies.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.Get(request.Id, cancellationToken);

            if (company == null)
                throw new NotFoundException(nameof(company), request.Id);

            _unitOfWork.CompanyRepository.Delete(company);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
