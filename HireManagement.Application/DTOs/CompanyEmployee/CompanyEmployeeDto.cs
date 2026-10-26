using HireManagement.Application.DTOs.Common;
using HireManagement.Application.DTOs.Company;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.CompanyEmployee
{
    public class CompanyEmployeeDto : PersonDto
    {
        public EmployeeType EmployeeType { get; set; }

        public int CompanyId { get; set; }
        public virtual CompanyDto? Company { get; set; }
    }
}
