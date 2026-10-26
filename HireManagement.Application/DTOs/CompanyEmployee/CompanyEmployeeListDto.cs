using HireManagement.Application.DTOs.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.CompanyEmployee
{
    public class CompanyEmployeeListDto : PersonListDto
    {
        public EmployeeType EmployeeType { get; set; }
    }
}
