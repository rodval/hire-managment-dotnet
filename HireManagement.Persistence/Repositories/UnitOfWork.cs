using HireManagement.Application.Contracts.Persistence;

namespace HireManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HireManagementDbContext _context;
        private IAdminRepository? _adminRepository;
        private ICompanyRepository? _companyRepository;
        private ICompanyEmployeeRepository? _companyEmployeeRepository;
        private IOpeningRepository? _openingRepository;
        private ICandidateRepository? _candidateRepository;
        private IOpeningApplicationRepository? _openingApplicationRepository;

        public UnitOfWork(HireManagementDbContext context)
        {
            _context = context;
        }

        public IAdminRepository AdminRepository =>
            _adminRepository ??= new AdminRepository(_context);

        public ICompanyRepository CompanyRepository =>
            _companyRepository ??= new CompanyRepository(_context);

        public ICompanyEmployeeRepository CompanyEmployeeRepository =>
            _companyEmployeeRepository ??= new CompanyEmployeeRepository(_context);

        public IOpeningRepository OpeningRepository =>
            _openingRepository ??= new OpeningRepository(_context);

        public ICandidateRepository CandidateRepository =>
            _candidateRepository ??= new CandidateRepository(_context);

        public IOpeningApplicationRepository OpeningApplicationRepository =>
            _openingApplicationRepository ??= new OpeningApplicationRepository(_context);

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
