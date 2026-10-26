using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Handlers.Queries;
using HireManagement.Application.Features.Companies.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Companies.Queries
{
    public class GetCompanyRequestHandlerTest
    {
        private readonly Mock<ICompanyRepository> _mockRepo;

        public GetCompanyRequestHandlerTest()
        {
            _mockRepo = MockCompanyRepository.GetCompanyRepository();
        }

        [Fact]
        public async Task GetCompanyTest()
        {
            var handler = new GetCompanyRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCompanyRequest() { CompanyId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<CompanyDto>();
            result.Id.ShouldBe(1);
        }
    }
}
