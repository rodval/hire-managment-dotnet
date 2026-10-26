using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.Openings.Handlers.Queries
{
    public class GetOpeningRequestHandler : IRequestHandler<GetOpeningRequest, OpeningDto?>
    {
        private readonly IOpeningRepository _repository;

        public GetOpeningRequestHandler(IOpeningRepository repository)
        {
            _repository = repository;
        }

        public async Task<OpeningDto?> Handle(GetOpeningRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.Get(request.OpeningId, cancellationToken);
            return opening.ToDto();
        }
    }
}
