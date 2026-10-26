using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockCandidateRepository
    {
        public static Mock<ICandidateRepository> GetCandidateRepository()
        {
            var candidates = new List<Candidate>
            {
                new Candidate
                {
                    Id = "1",
                    FirstName = "test1",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = "hashed:P@ssword1"
                },
                new Candidate
                {
                    Id = "2",
                    FirstName = "test2",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = "hashed:P@ssword2"
                }
            };

            var mockRepo = new Mock<ICandidateRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(candidates);
            mockRepo.Setup(r => r.Get("1", It.IsAny<CancellationToken>())).ReturnsAsync(candidates[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<Candidate>(), It.IsAny<CancellationToken>())).ReturnsAsync((Candidate candidate, CancellationToken _) =>
            {
                candidates.Add(candidate);
                return candidate;
            });

            return mockRepo;

        }
    }
}
