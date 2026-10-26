using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.CompanyEmployees.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Handlers.Commands
{
    internal class UpdateCompanyEmployeeCommandHandler: IRequestHandler<UpdateCompanyEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.CompanyEmployeeRepository.Get(request.Employee.Id ?? string.Empty, cancellationToken);

            if (employee is null)
                throw new NotFoundException(nameof(employee), request.Employee.Id);

            request.Employee.ApplyTo(employee);

            _unitOfWork.CompanyEmployeeRepository.Update(employee);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
