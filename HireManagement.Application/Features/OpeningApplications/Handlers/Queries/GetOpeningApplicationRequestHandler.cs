using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Application.Mappings;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Handlers.Queries
{
    public class GetOpeningApplicationRequestHandler : IRequestHandler<GetOpeningApplicationRequest, OpeningApplicationDto?>
    {
        private readonly IOpeningApplicationRepository _repository;

        public GetOpeningApplicationRequestHandler(IOpeningApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<OpeningApplicationDto?> Handle(GetOpeningApplicationRequest request, CancellationToken cancellationToken)
        {
            var application = await _repository.Get(request.OpeningApplicationId, cancellationToken);
            return application.ToDto();
        }
    }
}
