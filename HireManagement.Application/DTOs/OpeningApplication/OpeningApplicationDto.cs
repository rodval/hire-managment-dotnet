using HireManagement.Application.DTOs.Candidate;
using HireManagement.Application.DTOs.Common;
using HireManagement.Application.DTOs.CompanyEmployee;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.OpeningApplication
{
    public class OpeningApplicationDto : BaseDto
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public string? CompanyEmployeeId { get; set; }
        public virtual CompanyEmployeeDto? CompanyEmployee { get; set; }

        public string? CandidateId { get; set; }
        public virtual CandidateDto? Candidate { get; set; }
    }
}
