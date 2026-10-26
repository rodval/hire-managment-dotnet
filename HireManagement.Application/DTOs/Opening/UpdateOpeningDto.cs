using HireManagement.Application.DTOs.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.Opening
{
    public class UpdateOpeningDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DateExpiration { get; set; }
        public OpeningType OpeningType { get; set; }
    }
}
