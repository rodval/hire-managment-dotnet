using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;

namespace HireManagement.Persistence.Repositories
{
    public class CompanyEmployeeRepository : GenericRepository<CompanyEmployee>, ICompanyEmployeeRepository
    {
        public CompanyEmployeeRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
