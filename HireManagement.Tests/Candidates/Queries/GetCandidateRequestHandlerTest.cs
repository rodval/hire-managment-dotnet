using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Handlers.Queries;
using HireManagement.Application.Features.Candidates.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Candidates.Queries
{
    public class GetCandidateRequestHandlerTest
    {
        private readonly Mock<ICandidateRepository> _mockRepo;

        public GetCandidateRequestHandlerTest()
        {
            _mockRepo = MockCandidateRepository.GetCandidateRepository();
        }

        [Fact]
        public async Task GetCandidateTest()
        {
            var handler = new GetCandidateRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCandidateRequest() { CandidateId = "1" } , CancellationToken.None);

            result.ShouldBeOfType<CandidateDto>();
            result.Id.ShouldBe("1");
        }
    }
}
