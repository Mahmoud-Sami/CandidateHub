using CandidateHub.Domain.Entities;
using CandidateHub.Domain.Interfaces;
using CandidateHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CandidateHub.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Candidate candidate)
        {
            _context.Add(candidate);
        }

        public Task<Candidate?> GetByEmailAsync(string email)
        {
            return _context.Candidates
                .FirstOrDefaultAsync(c => c.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> IsExistsAsync(string email)
        {
            return await _context.Candidates.AnyAsync(c => c.Email.ToLower() == email.ToLower());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
