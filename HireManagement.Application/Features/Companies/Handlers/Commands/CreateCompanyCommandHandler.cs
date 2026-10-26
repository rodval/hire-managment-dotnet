using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.Companies.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Companies.Handlers.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponses> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var company = request.CreateCompany.ToEntity();

            company = await _unitOfWork.CompanyRepository.Add(company, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = company.Id.ToString();

            return response;
        }
    }
}
