using CandidateHub.Application.DTOs;
using CandidateHub.Domain.Entities;

namespace CandidateHub.Application.Mapping
{
    internal static class MappingExtensions
    {
        public static Candidate ToDomainEntity(this CreateCandidateDTO candidateDTO)
        {
            var candidate = Candidate.Create(candidateDTO.FirstName,
                candidateDTO.LastName,
                candidateDTO.Email,
                candidateDTO.PhoneNumber,
                candidateDTO.LinkedInUrl,
                candidateDTO.GitHubUrl,
                candidateDTO.Comments);


            foreach (var timeIntervalDTO in candidateDTO.CallTimesPreference)
            {
                candidate.AddCallTimePreference(timeIntervalDTO.ToDomainEntity());
            }

            return candidate;
        }

        public static TimeInterval ToDomainEntity(this TimeIntervalDTO timeIntervalDTO) => new TimeInterval(timeIntervalDTO.Start, timeIntervalDTO.End);
    
    }
}
