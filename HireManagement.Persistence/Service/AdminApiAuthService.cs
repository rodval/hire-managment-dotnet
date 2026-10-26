using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Models.Identity;
using HireManagement.Domain;
using Microsoft.Extensions.Options;

namespace HireManagement.Persistence.Service
{
    public class AdminApiAuthService : AuthService<AdminApi>, IAdminApiAuthService
    {
        public AdminApiAuthService(HireManagementDbContext dbContext, IPasswordHasher passwordHasher, IOptions<JwtSettings> jwtSettings)
            : base(dbContext, passwordHasher, jwtSettings)
        {
        }

        protected override string GetRole(AdminApi user) => "Administrator";
    }
}
