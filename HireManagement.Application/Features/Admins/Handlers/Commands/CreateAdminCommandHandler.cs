using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Features.Admins.Request.Commands;
using HireManagement.Application.Mappings;
using HireManagement.Application.Responses;
using MediatR;

namespace HireManagement.Application.Features.Admins.Handlers.Commands
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public CreateAdminCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<BaseCommandResponses> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var admin = request.CreateAdminApi.ToEntity();
            admin.PasswordHash = _passwordHasher.Hash(request.CreateAdminApi.Password ?? string.Empty);

            admin = await _unitOfWork.AdminRepository.Add(admin, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = admin.Id;

            return response;
        }
    }
}
