using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.OpeningApplication;
using HireManagement.Application.Features.OpeningApplications.Handlers.Commands;
using HireManagement.Application.Features.OpeningApplications.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Domain.Utilities;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.OpeningApplications.Commands
{
    public class CreateOpeningApplicationCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateOpeningApplicationDto _applicationDto;
        private readonly CreateOpeningApplicationCommandHandler _handler;

        public CreateOpeningApplicationCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateOpeningApplicationCommandHandler(_mockUow.Object);

            _applicationDto = new CreateOpeningApplicationDto
            {
                DateApplication = DateTime.Now,
                Status = ApplicationStatusType.InProcess,
                CompanyEmployeeId = "1",
                CandidateId = "1"
            };
        }

        [Fact]
        public async Task CreateApplicationTest()
        {
            var result = await _handler.Handle(new CreateOpeningApplicationCommand() { CreateOpeningApplication = _applicationDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(2);
        }
    }
}
