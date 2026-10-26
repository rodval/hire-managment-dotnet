using HireManagement.Domain;

namespace HireManagement.Application.Contracts.Persistence
{
    public interface IOpeningApplicationRepository : IGenericRepository<OpeningApplication>
    {
        Task<IReadOnlyList<OpeningApplication>> GetCandidateApplications(string candidateId, CancellationToken cancellationToken = default);
    }
}
