using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.DTOs.Admin;
using HireManagement.Application.Features.Admins.Handlers.Queries;
using HireManagement.Application.Features.Admins.Request.Queries;
using HireManagement.Tests.Mocks;
using Moq;
using Shouldly;

namespace HireManagement.Tests.Admins.Queries
{
    public class GetAdminListRequestHandlerTest
    {
        private readonly Mock<IAdminRepository> _mockRepo;
        public GetAdminListRequestHandlerTest()
        {
            _mockRepo = MockAdminRepository.GetAdminRepository();
        }

        [Fact]
        public async Task GetAdminListTest()
        {
            var handler = new GetAdminListRequestHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetAdminListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<AdminApiListDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
