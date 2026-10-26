using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using HireManagement.Domain.Utilities;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockOpeningRepository
    {
        public static Mock<IOpeningRepository> GetOpeningRepository()
        {
            var openings = new List<Opening>
            {
                new Opening
                {
                    Id = 1,
                    Title = "New Vacancy",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = DateTime.Now,
                    DateExpiration = DateTime.Now.AddDays(10),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = "1"
                }
            };

            var mockRepo = new Mock<IOpeningRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(openings);
            mockRepo.Setup(r => r.Get(1, It.IsAny<CancellationToken>())).ReturnsAsync(openings[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<Opening>(), It.IsAny<CancellationToken>())).ReturnsAsync((Opening opening, CancellationToken _) =>
            {
                openings.Add(opening);
                return opening;
            });

            return mockRepo;

        }
    }
}
