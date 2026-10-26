using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Companies.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Companies.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.Get(request.Company.Id, cancellationToken);

            if (company is null)
                throw new NotFoundException(nameof(company), request.Company.Id);

            request.Company.ApplyTo(company);

            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
