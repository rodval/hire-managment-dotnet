using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Admins.Handlers.Queries
{
    public class GetAdminRequestHandler : IRequestHandler<GetAdminRequest, AdminApiDto?>
    {
        private readonly IAdminRepository _repository;

        public GetAdminRequestHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdminApiDto?> Handle(GetAdminRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.Get(request.AdminId, cancellationToken);
            return admin.ToDto();
        }
    }
}
