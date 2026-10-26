using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Handlers.Queries;
using HireManagement.Application.Features.CompanyEmployees.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.CompanyEmployees.Queries
{
    public class GetCompanyEmployeeListRequestHandlerTest
    {
        private readonly Mock<ICompanyEmployeeRepository> _mockRepo;
        public GetCompanyEmployeeListRequestHandlerTest()
        {
            _mockRepo = MockCompanyEmployeeRepository.GetCompanyEmployeeRepository();
        }

        [Fact]
        public async Task GetCompanyEmployeeListTest()
        {
            var handler = new GetCompanyEmployeeListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCompanyEmployeeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CompanyEmployeeListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
