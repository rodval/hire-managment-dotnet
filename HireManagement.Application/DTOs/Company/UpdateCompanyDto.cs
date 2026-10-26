using HireManagement.Application.DTOs.Common;

namespace HireManagement.Application.DTOs.Company
{
    public class UpdateCompanyDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

        public string? AdminId { get; set; }
    }
}
