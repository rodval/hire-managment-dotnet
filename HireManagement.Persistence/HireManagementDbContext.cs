using HireManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HireManagement.Persistence
{
    public class HireManagementDbContext : DbContext
    {
        public HireManagementDbContext(DbContextOptions<HireManagementDbContext> options)
            : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HireManagementDbContext).Assembly);
        }

        public DbSet<AdminApi>? Admins { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<CompanyEmployee>? CompanyEmployees { get; set; }
        public DbSet<Opening>? Openings { get; set; }
        public DbSet<Candidate>? Candidates { get; set; }
        public DbSet<OpeningApplication>? OpeningApplications { get; set; }
    }
}
