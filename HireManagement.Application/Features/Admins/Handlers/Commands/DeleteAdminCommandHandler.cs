using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Admins.Request.Commands;
using MediatR;

namespace HireManagement.Application.Features.Admins.Handlers.Commands
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.Get(request.Id, cancellationToken);

            if (admin == null)
                throw new NotFoundException(nameof(admin), request.Id);

            _unitOfWork.AdminRepository.Delete(admin);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}