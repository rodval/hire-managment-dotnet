using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using HireManagement.Domain.Utilities;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockOpeningApplicationRepository
    {
        public static Mock<IOpeningApplicationRepository> GetOpeningApplicationRepository()
        {
            var applications = new List<OpeningApplication>
            {
                new OpeningApplication
                {
                    Id = 1,
                    DateApplication = DateTime.Now,
                    Status = ApplicationStatusType.InProcess,
                    CompanyEmployeeId = "1",
                    CandidateId = "1"
                }
            };

            var mockRepo = new Mock<IOpeningApplicationRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(applications);
            mockRepo.Setup(r => r.Get(1, It.IsAny<CancellationToken>())).ReturnsAsync(applications[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<OpeningApplication>(), It.IsAny<CancellationToken>())).ReturnsAsync((OpeningApplication application, CancellationToken _) =>
            {
                applications.Add(application);
                return application;
            });

            return mockRepo;

        }
    }
}
