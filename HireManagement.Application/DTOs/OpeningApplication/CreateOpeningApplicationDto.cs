using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.OpeningApplication
{
    public class CreateOpeningApplicationDto
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public string? CompanyEmployeeId { get; set; }

        public string? CandidateId { get; set; }
    }
}
