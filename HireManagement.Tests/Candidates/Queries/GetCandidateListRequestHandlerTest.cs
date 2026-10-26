using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Handlers.Queries;
using HireManagement.Application.Features.Candidates.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Candidates.Queries
{
    public class GetCandidateListRequestHandlerTest
    {
        private readonly Mock<ICandidateRepository> _mockRepo;
        public GetCandidateListRequestHandlerTest()
        {
            _mockRepo = MockCandidateRepository.GetCandidateRepository();
        }

        [Fact]
        public async Task GetCandidateListTest()
        {
            var handler = new GetCandidateListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCandidateListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CandidateListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
