using HireManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireManagement.Persistence.Entities
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasData(
                new Candidate
                {
                    Id = "1",
                    FirstName = "Omar",
                    LastName = "Strange",
                    Age = 32,
                    Email = "rodrigovalladares1@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password1
                },
                new Candidate
                {
                    Id = "2",
                    FirstName = "Ruben",
                    LastName = "Dario",
                    Age = 32,
                    Email = "candidate2@gmail.com",
                    PasswordHash = SeedPasswordHashes.Password2
                }
            );
        }
    }
}
