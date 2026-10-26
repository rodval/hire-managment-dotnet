using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Application.Features.CompanyEmployees.Handlers.Queries;
using HireManagement.Application.Features.CompanyEmployees.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.CompanyEmployees.Queries
{
    public class GetCompanyEmployeeRequestHandlerTest
    {
        private readonly Mock<ICompanyEmployeeRepository> _mockRepo;

        public GetCompanyEmployeeRequestHandlerTest()
        {
            _mockRepo = MockCompanyEmployeeRepository.GetCompanyEmployeeRepository();
        }

        [Fact]
        public async Task GetCompanyEmployeeTest()
        {
            var handler = new GetCompanyEmployeeRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetCompanyEmployeeRequest() { CompanyEmployeeId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<CompanyEmployeeDto>();
            result.Id.ShouldBe("1");
        }
    }
}
