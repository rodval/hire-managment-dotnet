using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Handlers.Queries;
using HireManagement.Application.Features.Admins.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Admins.Queries
{
    public class GetAdminRequestHandlerTest
    {
        private readonly Mock<IAdminRepository> _mockRepo;

        public GetAdminRequestHandlerTest()
        {
            _mockRepo = MockAdminRepository.GetAdminRepository();
        }

        [Fact]
        public async Task GetAdminTest()
        {
            var handler = new GetAdminRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetAdminRequest() { AdminId = "1" }, CancellationToken.None);

            result.ShouldBeOfType<AdminApiDto>();
            result.Id.ShouldBe("1");
        }
    }
}
