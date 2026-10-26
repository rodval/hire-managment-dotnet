using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Opening;
using HireManagement.Application.Features.Openings.Handlers.Commands;
using HireManagement.Application.Features.Openings.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Domain.Utilities;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Openings.Commands
{
    public class CreateOpeningCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateOpeningDto _openingDto;
        private readonly CreateOpeningCommandHandler _handler;

        public CreateOpeningCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateOpeningCommandHandler(_mockUow.Object);

            _openingDto = new CreateOpeningDto
            {
                Title = "New Vacancy",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                DateCreated = DateTime.Now,
                DateExpiration = DateTime.Now.AddDays(10),
                OpeningType = OpeningType.Valid,
                CompanyEmployeeId = "1"
            };
        }

        [Fact]
        public async Task CreateOpeningTest()
        {
            var result = await _handler.Handle(new CreateOpeningCommand() { CreateOpening = _openingDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(2);
        }
    }
}
