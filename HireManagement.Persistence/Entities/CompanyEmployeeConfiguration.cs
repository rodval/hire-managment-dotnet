using HireManagement.Domain;
using HireManagement.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireManagement.Persistence.Entities
{
    public class CompanyEmployeeConfiguration : IEntityTypeConfiguration<CompanyEmployee>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
        {
            builder.HasData(
                new CompanyEmployee
                {
                    Id = "1",
                    FirstName = "Henry",
                    LastName = "Walas",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password1,
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 1
                },
                new CompanyEmployee
                {
                    Id = "2",
                    FirstName = "Brook",
                    LastName = "Bane",
                    Age = 32,
                    Email = "employee2@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password2,
                    EmployeeType = EmployeeType.Employee,
                    CompanyId = 1
                },
                new CompanyEmployee
                {
                    Id = "3",
                    FirstName = "Harry",
                    LastName = "Stevens",
                    Age = 32,
                    Email = "employee3@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password3,
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 2
                },
                new CompanyEmployee
                {
                    Id = "4",
                    FirstName = "Alfonse",
                    LastName = "Elric",
                    Age = 32,
                    Email = "employee4@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password4,
                    EmployeeType = EmployeeType.CompanyAdmin,
                    CompanyId = 3
                }
            );
        }
    }
}
