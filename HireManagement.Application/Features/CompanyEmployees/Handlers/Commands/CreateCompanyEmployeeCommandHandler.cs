using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.CompanyEmployees.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Handlers.Commands
{
    public class CreateCompanyEmployeeCommandHandler : IRequestHandler<CreateCompanyEmployeeCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseCommandResponses> Handle(CreateCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var employee = request.CreateEmployee.ToEntity();
            employee.PasswordHash = _passwordHasher.Hash(request.CreateEmployee.Password ?? string.Empty);

            employee = await _unitOfWork.CompanyEmployeeRepository.Add(employee, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = employee.Id;

            return response;
        }
    }
}
