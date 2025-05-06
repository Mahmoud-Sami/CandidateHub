using System.Text.RegularExpressions;
using CandidateHub.Domain.Utilities;

namespace CandidateHub.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public List<TimeInterval> CallTimesPreference { get; set; }
        public string? LinkedInUrl { get; private set; }
        public string? GitHubUrl { get; private set; }
        public string? Comments { get; private set; }

        private Candidate()
        {
            CallTimesPreference = new List<TimeInterval>();
        }

        public static Candidate Create(string firstName, string lastName, string email, string phoneNumber,
            string? linkedInUrl = null, string? gitHubUrl = null, string? comments = null)
        {
            Candidate candidate = new Candidate();
            candidate.FirstName = firstName;
            candidate.LastName = lastName;

            candidate.SetEmail(email);
            candidate.SetPhoneNumber(phoneNumber);

            candidate.SetLinkedInUrl(linkedInUrl);
            candidate.SetGitHubUrl(gitHubUrl);
            candidate.Comments = comments;

            return candidate;
        }

        public void AddCallTimePreference(TimeInterval callTime)
        {
            if (callTime == null)
                throw new ArgumentNullException(nameof(callTime));

            if (callTime.Start >= callTime.End)
                throw new ArgumentException("Start time must be less than end time");

            this.CallTimesPreference.Add(callTime);
        }

        public void SetGitHubUrl(string? githubUrl)
        {
            if (githubUrl == null) 
                throw new ArgumentNullException(nameof(githubUrl));

            if (Regex.IsMatch(githubUrl, RegexPatterns.GitHubProfileUrlPattern))
                this.GitHubUrl = githubUrl;
            else
                throw new ArgumentException("Invalid GitHub URL");
        }

        public void SetLinkedInUrl(string? linkedInUrl)
        {
            if (linkedInUrl == null) 
                throw new ArgumentNullException(nameof(linkedInUrl));

            if (Regex.IsMatch(linkedInUrl, RegexPatterns.LinkedInProfileUrlPattern))
                this.LinkedInUrl = linkedInUrl;
            else
                throw new ArgumentException("Invalid LinkedIn URL");
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber));

            if (Regex.IsMatch(phoneNumber, RegexPatterns.PhoneNumberPattern))
                this.PhoneNumber = phoneNumber;
            else
                throw new ArgumentException("Invalid Phone Number");
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (Regex.IsMatch(email, RegexPatterns.EmailPattern))
                this.Email = email;
            else
                throw new ArgumentException("Invalid Email");
        }
    }
}
