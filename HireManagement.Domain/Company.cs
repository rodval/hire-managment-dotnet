using HireManagement.Domain.Common;

namespace HireManagement.Domain
{
    public class Company : BaseDomainEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

        public string? AdminId { get; set; }
        public virtual AdminApi? Admin { get; set; }
    }
}
