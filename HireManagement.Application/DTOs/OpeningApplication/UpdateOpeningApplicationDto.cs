using HireManagement.Application.DTOs.Common;
using HireManagement.Domain.Utilities;

namespace HireManagement.Application.DTOs.OpeningApplication
{
    public class UpdateOpeningApplicationDto : BaseDto
    {
        public ApplicationStatusType Status { get; set; }
    }
}
