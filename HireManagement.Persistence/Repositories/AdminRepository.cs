using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;

namespace HireManagement.Persistence.Repositories
{
    public class AdminRepository : GenericRepository<AdminApi>, IAdminRepository
    {
        public AdminRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
