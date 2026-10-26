using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Exceptions;
using HireManagement.Application.Features.Admins.Request.Commands;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Admins.Handlers.Commands
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdminCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.Get(request.AdminApi.Id ?? string.Empty, cancellationToken);

            if (admin is null)
                throw new NotFoundException(nameof(admin), request.AdminApi.Id);

            request.AdminApi.ApplyTo(admin);

            _unitOfWork.AdminRepository.Update(admin);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
