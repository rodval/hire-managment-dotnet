using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using HireManagement.Domain.Utilities;
using Moq;

namespace HireManagement.Tests.Mocks
{
    public class MockCompanyEmployeeRepository
    {
        public static Mock<ICompanyEmployeeRepository> GetCompanyEmployeeRepository()
        {
            var employees = new List<CompanyEmployee>
            {
                new CompanyEmployee
                {
                    Id = "1",
                    FirstName = "Henry",
                    LastName = "Walas",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = "hashed:P@ssword1",
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 1
                },
                new CompanyEmployee
                {
                    Id = "2",
                    FirstName = "Brook",
                    LastName = "Bane",
                    Age = 32,
                    Email = "employee2@gmail.com",
                    PasswordHash = "hashed:P@ssword2",
                    EmployeeType = EmployeeType.Employee,
                    CompanyId = 1
                }
            };

            var mockRepo = new Mock<ICompanyEmployeeRepository>();

            mockRepo.Setup(r => r.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(employees);
            mockRepo.Setup(r => r.Get("1", It.IsAny<CancellationToken>())).ReturnsAsync(employees[0]);

            mockRepo.Setup(r => r.Add(It.IsAny<CompanyEmployee>(), It.IsAny<CancellationToken>())).ReturnsAsync((CompanyEmployee employee, CancellationToken _) =>
            {
                employees.Add(employee);
                return employee;
            });

            return mockRepo;

        }
    }
}
