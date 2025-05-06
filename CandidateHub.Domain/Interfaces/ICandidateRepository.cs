using CandidateHub.Domain.Entities;

namespace CandidateHub.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        void Add(Candidate candidate);
        Task<Candidate?> GetByEmailAsync(string email);
        Task<bool> IsExistsAsync(string email);
        void RemoveTimeIntervals(List<TimeInterval> timeIntervals);
        Task<int> SaveChangesAsync();
    }
}
