using HireManagement.Application.DTOs.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.OpeningApplication
{
    public class OpeningApplicationListDto : BaseDto
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public string? CompanyEmployeeId { get; set; }

        public string? CandidateId { get; set; }
    }
}
