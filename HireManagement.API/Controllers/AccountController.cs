using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAdminApiAuthService _adminApiAuthService;
        private readonly ICandidateAuthService _candidateAuthService;
        private readonly ICompanyEmployeeAuthService _companyEmployeeAuthService;

        public AccountController(IAdminApiAuthService adminApiAuthService, ICandidateAuthService candidateAuthService, ICompanyEmployeeAuthService companyEmployeeAuthService)
        {
            _adminApiAuthService = adminApiAuthService;
            _candidateAuthService = candidateAuthService;
            _companyEmployeeAuthService = companyEmployeeAuthService;
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult<AuthResponse>> LoginAdmin(AuthRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _adminApiAuthService.Login(request, cancellationToken));
        }

        [HttpPost("employee/login")]
        public async Task<ActionResult<AuthResponse>> LoginEmployee(AuthRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _companyEmployeeAuthService.Login(request, cancellationToken));
        }

        [HttpPost("candidate/login")]
        public async Task<ActionResult<AuthResponse>> LoginCandidate(AuthRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _candidateAuthService.Login(request, cancellationToken));
        }
    }
}
