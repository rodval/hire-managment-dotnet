using HireManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireManagement.Persistence.Entities
{
    public class AdminConfiguration : IEntityTypeConfiguration<AdminApi>
    {
        public void Configure(EntityTypeBuilder<AdminApi> builder)
        {
            builder.HasData(
                new AdminApi
                {
                    Id = "1",
                    FirstName = "Robert",
                    LastName = "Wade",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password1
                },
                new AdminApi
                {
                    Id = "2",
                    FirstName = "Felix",
                    LastName = "Feliz",
                    Age= 32,
                    Email = "rodrigovalladares@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password2
                }
            );
        }
    }
}
