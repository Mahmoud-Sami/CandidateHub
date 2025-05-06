using CandidateHub.Domain.Entities;

namespace CandidateHub.Application.DTOs
{
    public record CreateCandidateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<TimeIntervalDTO> CallTimesPreference { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Comments { get; set; }
    }
}
