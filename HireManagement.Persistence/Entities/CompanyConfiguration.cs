using HireManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireManagement.Persistence.Entities
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id = 1,
                    Name = "Naughty Dog",
                    Description = "company 1",
                    Address = "address",
                    AdminId = "1"
                },
                new Company
                {
                    Id = 2,
                    Name = "Riot Games",
                    Description = "company 2",
                    Address = "address",
                    AdminId = "2"
                },
                new Company
                {
                    Id = 3,
                    Name = "Miami Heat",
                    Description = "company 3",
                    Address = "address",
                    AdminId = "2"
                }
            );
        }
    }
}
