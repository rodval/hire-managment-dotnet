using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Handlers.Commands;
using HireManagement.Application.Features.Companies.Request.Commands;
using HireManagement.Application.Responses;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Companies.Commands
{
    public class CreateCompanyCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCompanyDto _companyDto;
        private readonly CreateCompanyCommandHandler _handler;

        public CreateCompanyCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            _handler = new CreateCompanyCommandHandler(_mockUow.Object);

            _companyDto = new CreateCompanyDto
            {
                Name = "Naughty Dog",
                Description = "company 1",
                Address = "address",
                AdminId = "1"
            };
        }

        [Fact]
        public async Task CreateCompanyTest()
        {
            var result = await _handler.Handle(new CreateCompanyCommand() { CreateCompany = _companyDto }, CancellationToken.None);

            var companies = await _mockUow.Object.CompanyRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            companies.Count.ShouldBe(3);
        }
    }
}
