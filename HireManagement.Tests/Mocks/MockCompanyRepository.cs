using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockCompanyRepository
    {
        public static Mock<ICompanyRepository> GetCompanyRepository()
        {
            var companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Naughty Dog",
                    Description = "company 1",
                    Address = "address",
                    AdminId = "1"
                },
                new Company
                {
                    Id = 2,
                    Name = "Riot Games",
                    Description = "company 2",
                    Address = "address",
                    AdminId = "2"
                }
            };

            var mockRepo = new Mock<ICompanyRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(companies);
            mockRepo.Setup(r => r.Get(1, It.IsAny<CancellationToken>())).ReturnsAsync(companies[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<Company>(), It.IsAny<CancellationToken>())).ReturnsAsync((Company company, CancellationToken _) =>
            {
                companies.Add(company);
                return company;
            });

            return mockRepo;

        }
    }
}
