using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.CompanyEmployees.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.CompanyEmployees.Handlers.Commands
{
    public class DeleteCompanyEmployeeCommandHandler : IRequestHandler<DeleteCompanyEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.CompanyEmployeeRepository.Get(request.Id, cancellationToken);

            if (employee == null)
                throw new NotFoundException(nameof(employee), request.Id);

            _unitOfWork.CompanyEmployeeRepository.Delete(employee);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
