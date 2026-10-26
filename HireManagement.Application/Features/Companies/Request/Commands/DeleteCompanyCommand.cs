using MediatR;

namespace HireManagement.Application.Features.Companies.Request.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public required int Id { get; set; }
    }
}
