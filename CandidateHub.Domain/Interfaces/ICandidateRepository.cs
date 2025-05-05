using CandidateHub.Domain.Entities;

namespace CandidateHub.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllAsync(int page = 1, int pageSize = 10);
        Task<Candidate> GetByIdAsync(int id);
        Task<Candidate> GetByEmailAsync(string email);
        Task<Candidate> CreateAsync(Candidate candidate);
        Task<Candidate> UpdateAsync(Candidate candidate);
        Task<bool> IsExistsAsync(string email);
        Task<int> SaveChangesAsync();
    }
}
