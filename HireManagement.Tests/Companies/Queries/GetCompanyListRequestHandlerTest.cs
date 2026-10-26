using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Company;
using HireManagement.Application.Features.Companies.Handlers.Queries;
using HireManagement.Application.Features.Companies.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Companies.Queries
{
    public class GetCompanyListRequestHandlerTest
    {
        private readonly Mock<ICompanyRepository> _mockRepo;
        public GetCompanyListRequestHandlerTest()
        {
            _mockRepo = MockCompanyRepository.GetCompanyRepository();
        }

        [Fact]
        public async Task GetCompanyListTest()
        {
            var handler = new GetCompanyListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCompanyListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CompanyListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
