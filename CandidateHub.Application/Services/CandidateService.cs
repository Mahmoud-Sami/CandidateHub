using System.Text.RegularExpressions;
using CandidateHub.Application.Common;
using CandidateHub.Application.Mapping;
using CandidateHub.Application.Requests;
using CandidateHub.Application.Response;
using CandidateHub.Domain.Entities;
using CandidateHub.Domain.Interfaces;
using CandidateHub.Domain.Utilities;

namespace CandidateHub.Application.Services
{
    public class CandidateService
    {
        public ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Result<CandidateResponse>> CreateOrUpdateCandidateAsync(CreateCandidateRequest candidateDto)
        {
            var result = ValidateCandidateData(candidateDto);
            if (!result.IsSuccess)
                return result;

            Candidate? candidate = await _candidateRepository.GetByEmailAsync(candidateDto.Email);

            if (candidate is null)
                candidate = await CreateCandidate(candidateDto);
            else
                await UpdateCandidate(candidate, candidateDto);
            
            await _candidateRepository.SaveChangesAsync();
            return Result<CandidateResponse>.Success(new CandidateResponse(candidate));
        }

        private Result<CandidateResponse> ValidateCandidateData(CreateCandidateRequest candidateDto)
        {
            if (string.IsNullOrEmpty(candidateDto.FirstName) || string.IsNullOrEmpty(candidateDto.LastName))
                return Result<CandidateResponse>.Failure("First name and last name are required.");

            if (string.IsNullOrEmpty(candidateDto.Email))
                return Result<CandidateResponse>.Failure("Email is required.");

            if (string.IsNullOrEmpty(candidateDto.PhoneNumber))
                return Result<CandidateResponse>.Failure("PhoneNumber is required.");

            if (!Regex.IsMatch(candidateDto.Email, RegexPatterns.EmailPattern))
                return Result<CandidateResponse>.Failure("Email is invalid.");

            if (!Regex.IsMatch(candidateDto.PhoneNumber, RegexPatterns.PhoneNumberPattern))
                return Result<CandidateResponse>.Failure("PhoneNumber is invalid.");

            if (!Regex.IsMatch(candidateDto.GitHubUrl, RegexPatterns.GitHubProfileUrlPattern))
                return Result<CandidateResponse>.Failure("GitHub Url is invalid.");

            if (!Regex.IsMatch(candidateDto.LinkedInUrl, RegexPatterns.LinkedInProfileUrlPattern))
                return Result<CandidateResponse>.Failure("LinkedIn Url is invalid.");

            if (!candidateDto.CallTimesPreference.Any())
                return Result<CandidateResponse>.Failure("At least one call time preference is required.");

            foreach (var timeInterval in candidateDto.CallTimesPreference)
            {
                if (timeInterval.End <= timeInterval.Start)
                    return Result<CandidateResponse>.Failure("End time must be greater than start time.");
            }
            return Result<CandidateResponse>.Success(default);
        }

        private async Task<Candidate> CreateCandidate(CreateCandidateRequest candidateDto)
        {
            Candidate new_candidate = candidateDto.ToDomainEntity();
            _candidateRepository.Add(new_candidate);
            return new_candidate;
        }

        private async Task UpdateCandidate(Candidate candidate, CreateCandidateRequest candidateDto)
        {
            if (candidateDto.CallTimesPreference is not null)
            {
                _candidateRepository.RemoveTimeIntervals(candidate.CallTimesPreference);
            }

            candidate.Update(candidateDto.FirstName,
                    candidateDto.LastName,
                    candidateDto.PhoneNumber,
                    candidateDto.LinkedInUrl,
                    candidateDto.GitHubUrl,
                    candidateDto.Comments,
                    candidateDto.CallTimesPreference.Select(i => i.ToDomainEntity()).ToList());
        }

        public async Task<Result<CandidateResponse>> GetByEmailAsyn(string email)
        {
            Candidate? candidate = await _candidateRepository.GetByEmailAsync(email);
            if (candidate is null)
                return Result<CandidateResponse>.Failure("Candidate is not found");

            return Result<CandidateResponse>.Success(new CandidateResponse(candidate));
        }
    }
}
