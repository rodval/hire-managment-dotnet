using HireManagement.Application.DTOs.Common;

namespace HireManagement.Application.DTOs.Company
{
    public class CompanyListDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
    }
}
