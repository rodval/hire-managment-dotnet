using HireManagement.Application.Contracts.Persistence;
using HireManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HireManagement.Persistence.Repositories
{
    public class OpeningApplicationRepository : GenericRepository<OpeningApplication>, IOpeningApplicationRepository
    {
        public OpeningApplicationRepository(HireManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<OpeningApplication>> GetCandidateApplications(string candidateId, CancellationToken cancellationToken = default) =>
            await _dbContext.Set<OpeningApplication>()
                .Where(o => o.CandidateId == candidateId)
                .ToListAsync(cancellationToken);
    }
}
