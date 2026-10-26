using HireManagement.Domain;
using HireManagement.Domain.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireManagement.Persistence.Entities
{
    public class OpeningConfiguration : IEntityTypeConfiguration<Opening>
    {
        private static readonly DateTime SeedDate = new(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public void Configure(EntityTypeBuilder<Opening> builder)
        {
            builder.HasData(
                new Opening
                {
                    Id = 1,
                    Title = "New Vacancy",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = SeedDate,
                    DateExpiration = SeedDate.AddDays(10),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = "1"
                },
                new Opening
                {
                    Id = 2,
                    Title = "New Vacancy 2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.",
                    DateCreated = SeedDate,
                    DateExpiration = SeedDate.AddDays(25),
                    OpeningType = OpeningType.Valid,
                    CompanyEmployeeId = "3"
                }
            );
        }
    }
}
