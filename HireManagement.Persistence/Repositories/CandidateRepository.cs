using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;

namespace HireManagement.Persistence.Repositories
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
