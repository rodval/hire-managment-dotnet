using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Handlers.Queries;
using HireManagement.Application.Features.Openings.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Openings.Queries
{
    public class GetOpeningListRequestHandlerTest
    {
        private readonly Mock<IOpeningRepository> _mockRepo;
        public GetOpeningListRequestHandlerTest()
        {
            _mockRepo = MockOpeningRepository.GetOpeningRepository();
        }

        [Fact]
        public async Task GetOpeningListTest()
        {
            var handler = new GetOpeningListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetOpeningListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OpeningListDto>>();

            result.Count.ShouldBe(1);
        }
    }
}
