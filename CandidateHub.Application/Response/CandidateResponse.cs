using CandidateHub.Application.Requests;
using CandidateHub.Domain.Entities;

namespace CandidateHub.Application.Response
{
    public record CandidateResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<TimeIntervalDTO> CallTimesPreference { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string Comments { get; set; }

        public CandidateResponse(Candidate candidate)
        {
            this.FirstName = candidate.FirstName;
            this.LastName = candidate.LastName;
            this.Email = candidate.Email;
            this.PhoneNumber = candidate.PhoneNumber;
            this.LinkedInUrl = candidate.LinkedInUrl;
            this.GitHubUrl = candidate.GitHubUrl;
            this.Comments = candidate.Comments;

            this.CallTimesPreference = candidate.CallTimesPreference.Select(i => new TimeIntervalDTO(i.Start, i.End));
        }
    }
}
