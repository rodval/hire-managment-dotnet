using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.Features.Candidates.Handlers.Commands;
using HireManagement.Application.Features.Candidates.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Candidates.Commands
{
    public class CreateCandidateCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCandidateDto _candidateDto;
        private readonly CreateCandidateCommandHandler _handler;

        public CreateCandidateCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateCandidateCommandHandler(_mockUow.Object, new FakePasswordHasher());

            _candidateDto = new CreateCandidateDto
            {
                FirstName = "Robert",
                LastName = "Wade",
                Age = 32,
                Email = "rodrigovalladares1@gmail.com",
                Password = "P@ssword1"
            };
        }

        [Fact]
        public async Task CreateCandidateTest()
        {
            var result = await _handler.Handle(new CreateCandidateCommand() { CreateCandidate = _candidateDto }, CancellationToken.None);

            var candidates = await _mockUow.Object.CandidateRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            candidates.Count.ShouldBe(3);

            candidates[^1].PasswordHash.ShouldBe("hashed:P@ssword1");
        }
    }
}
