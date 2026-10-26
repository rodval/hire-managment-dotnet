using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockAdminRepository
    {
        public static Mock<IAdminRepository> GetAdminRepository()
        {
            var admins = new List<AdminApi>
            {
                new AdminApi
                {
                    Id = "1",
                    FirstName = "test1",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = "hashed:P@ssword1"
                },
                new AdminApi
                {
                    Id = "2",
                    FirstName = "test2",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = "hashed:P@ssword2"
                }
            };

            var mockRepo = new Mock<IAdminRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(admins);
            mockRepo.Setup(r => r.Get("1", It.IsAny<CancellationToken>())).ReturnsAsync(admins[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<AdminApi>(), It.IsAny<CancellationToken>())).ReturnsAsync((AdminApi admin, CancellationToken _) =>
            {
                admins.Add(admin);
                return admin;
            });

            return mockRepo;

        }
    }
}
