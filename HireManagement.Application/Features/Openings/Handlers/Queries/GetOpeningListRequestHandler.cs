using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Openings.Handlers.Queries
{
    public class GetOpeningListRequestHandler : IRequestHandler<GetOpeningListRequest, List<OpeningListDto>>
    {
        private readonly IOpeningRepository _repository;

        public GetOpeningListRequestHandler(IOpeningRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<OpeningListDto>> Handle(GetOpeningListRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.GetAll(cancellationToken);
            return opening.ToListDtos();
        }
    }
}
