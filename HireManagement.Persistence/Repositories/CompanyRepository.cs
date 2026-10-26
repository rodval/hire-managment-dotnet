using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;

namespace HireManagement.Persistence.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
