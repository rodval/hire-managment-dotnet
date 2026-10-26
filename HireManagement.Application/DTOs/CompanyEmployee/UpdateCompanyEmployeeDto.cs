using HireManagement.Application.DTOs.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.CompanyEmployee
{
    public class UpdateCompanyEmployeeDto : PersonDto
    {
        public EmployeeType EmployeeType { get; set; }
        public int CompanyId { get; set; }
    }
}
