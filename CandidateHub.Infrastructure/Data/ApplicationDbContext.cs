using CandidateHub.Domain.Entities;
using CandidateHub.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<TimeInterval> TimeInterval { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
        }
    }
}
