using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.CompanyEmployee
{
    public class CreateCompanyEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public string? Password { get; set; }

        public int CompanyId { get; set; }
    }
}
