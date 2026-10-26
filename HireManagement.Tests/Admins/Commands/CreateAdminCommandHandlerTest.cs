using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Handlers.Commands;
using HireManagement.Application.Features.Admins.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Admins.Commands
{
    public class CreateAdminCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateAdminApiDto _adminDto;
        private readonly CreateAdminCommandHandler _handler;

        public CreateAdminCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateAdminCommandHandler(_mockUow.Object, new FakePasswordHasher());

            _adminDto = new CreateAdminApiDto
            {
                FirstName = "Robert",
                LastName = "Wade",
                Age = 32,
                Email = "rodrigovalladares1@gmail.com",
                Password = "P@ssword1"
            };
        }

        [Fact]
        public async Task CreateAdminTest()
        {
            var result = await _handler.Handle(new CreateAdminCommand() { CreateAdminApi = _adminDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(3);

            admins[^1].PasswordHash.ShouldBe("hashed:P@ssword1");
        }
    }
}
