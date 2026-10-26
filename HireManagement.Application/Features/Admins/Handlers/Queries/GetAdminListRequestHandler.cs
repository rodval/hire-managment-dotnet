using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Admins.Handlers.Queries
{
    public class GetAdminListRequestHandler : IRequestHandler<GetAdminListRequest, List<AdminApiListDto>>
    {
        private readonly IAdminRepository _repository;

        public GetAdminListRequestHandler(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AdminApiListDto>> Handle(GetAdminListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAll(cancellationToken);
            return admin.ToListDtos();
        }
    }
}
