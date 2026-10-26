using HireManagement.Application.DTOs.OpeningApplication;
using MediatR;

namespace HireManagement.Application.Features.OpeningApplications.Request.Queries
{
    public class GetCandidateApplicationListRequest : IRequest<List<OpeningApplicationListDto>>
    {
        public required string CandidateId { get; set; }
    }
}
