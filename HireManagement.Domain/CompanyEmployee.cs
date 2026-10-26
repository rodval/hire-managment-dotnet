using HireManagement.Domain.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Domain
{
    public class CompanyEmployee : Person
    {
        public EmployeeType EmployeeType { get; set; }

        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
    }
}
