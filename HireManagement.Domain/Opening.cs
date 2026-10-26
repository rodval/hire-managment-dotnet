using HireManagement.Domain.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Domain
{
    public class Opening : BaseDomainEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateExpiration { get; set; }
        public OpeningType OpeningType { get; set; }

        public string? CompanyEmployeeId { get; set; }
        public virtual CompanyEmployee? CompanyEmployee { get; set; }
    }
}
