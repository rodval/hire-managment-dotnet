using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Handlers.Queries;
using HireManagement.Application.Features.Openings.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Openings.Queries
{
    public class GetOpeningRequestHandlerTest
    {
        private readonly Mock<IOpeningRepository> _mockRepo;

        public GetOpeningRequestHandlerTest()
        {
            _mockRepo = MockOpeningRepository.GetOpeningRepository();
        }

        [Fact]
        public async Task GetOpeningTest()
        {
            var handler = new GetOpeningRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetOpeningRequest() { OpeningId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<OpeningDto>();
            result.Id.ShouldBe(1);
        }
    }
}
