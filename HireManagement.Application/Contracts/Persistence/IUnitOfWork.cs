namespace HireManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IAdminRepository AdminRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICompanyEmployeeRepository CompanyEmployeeRepository { get; }
        IOpeningRepository OpeningRepository { get; }
        ICandidateRepository CandidateRepository { get; }
        IOpeningApplicationRepository OpeningApplicationRepository { get; }
        Task Save(CancellationToken cancellationToken = default);
    }
}
