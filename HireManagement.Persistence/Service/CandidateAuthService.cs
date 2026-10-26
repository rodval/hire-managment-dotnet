using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Models.Identity;
using HireManagement.Domain;
using Microsoft.Extensions.Options;

namespace HireManagement.Persistence.Service
{
    public class CandidateAuthService : AuthService<Candidate>, ICandidateAuthService
    {
        public CandidateAuthService(HireManagementDbContext dbContext, IPasswordHasher passwordHasher, IOptions<JwtSettings> jwtSettings)
            : base(dbContext, passwordHasher, jwtSettings)
        {
        }

        protected override string GetRole(Candidate user) => "Candidate";
    }
}
