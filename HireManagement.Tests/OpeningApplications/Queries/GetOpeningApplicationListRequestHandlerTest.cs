using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Handlers.Queries;
using HireManagement.Application.Features.OpeningApplications.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.OpeningApplications.Queries
{
    public class GetOpeningApplicationListRequestHandlerTest
    {
        private readonly Mock<IOpeningApplicationRepository> _mockRepo;
        public GetOpeningApplicationListRequestHandlerTest()
        {
            _mockRepo = MockOpeningApplicationRepository.GetOpeningApplicationRepository();
        }

        [Fact]
        public async Task GetApplicationListTest()
        {
            var handler = new GetOpeningApplicationListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetOpeningApplicationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OpeningApplicationListDto>>();

            result.Count.ShouldBe(1);
        }
    }
}
