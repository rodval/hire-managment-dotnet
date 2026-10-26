using HireManagement.Domain.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Domain
{
    public class OpeningApplication : BaseDomainEntity
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public string? CompanyEmployeeId { get; set; }
        public virtual CompanyEmployee? CompanyEmployee { get; set; }

        public string? CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
    }
}
