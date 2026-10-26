using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Handlers.Commands;
using HireManagement.Application.Features.CompanyEmployees.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Domain.Utilities;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.CompanyEmployees.Commands
{
    public class CreateCompanyEmployeeCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCompanyEmployeeDto _employeeDto;
        private readonly CreateCompanyEmployeeCommandHandler _handler;

        public CreateCompanyEmployeeCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateCompanyEmployeeCommandHandler(_mockUow.Object, new FakePasswordHasher());

            _employeeDto = new CreateCompanyEmployeeDto
            {
                FirstName = "Brook",
                LastName = "Bane",
                Age = 32,
                Email = "employee2@gmail.com",
                Password = "P@ssword1",
                EmployeeType = EmployeeType.Employee,
                CompanyId = 1
            };
        }

        [Fact]
        public async Task CreateEmployeeTest()
        {
            var result = await _handler.Handle(new CreateCompanyEmployeeCommand() { CreateEmployee = _employeeDto }, CancellationToken.None);

            var admins = await _mockUow.Object.CompanyEmployeeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(3);

            admins[^1].PasswordHash.ShouldBe("hashed:P@ssword1");
        }
    }
}
