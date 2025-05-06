using CandidateHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateHub.Infrastructure.EntityConfiguration
{
    internal class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(e => e.LinkedInUrl).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.GitHubUrl).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.Comments).IsRequired(false);

            builder.HasMany(e => e.CallTimesPreference)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
