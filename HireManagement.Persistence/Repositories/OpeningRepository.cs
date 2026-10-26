using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;

namespace HireManagement.Persistence.Repositories
{
    public class OpeningRepository : GenericRepository<Opening>, IOpeningRepository
    {
        public OpeningRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
