using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Handlers.Queries;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.OpeningApplications.Queries
{
    public class GetOpeningApplicationRequestHandlerTest
    {
        private readonly Mock<IOpeningApplicationRepository> _mockRepo;

        public GetOpeningApplicationRequestHandlerTest()
        {
            _mockRepo = MockOpeningApplicationRepository.GetOpeningApplicationRepository();
        }

        [Fact]
        public async Task GetOpeningApplicationTest()
        {
            var handler = new GetOpeningApplicationRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetOpeningApplicationRequest() { OpeningApplicationId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<OpeningApplicationDto>();
            result.Id.ShouldBe(1);
        }
    }
}
