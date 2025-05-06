namespace CandidateHub.Domain.Utilities
{
    public static class RegexPatterns
    {
        public const string GitHubProfileUrlPattern = @"^(?:https?:\/\/)?(?:www\.)?github\.com\/[A-Za-z0-9-]+\/?$";
        public const string LinkedInProfileUrlPattern = @"^(?:https?:\/\/)?(?:www\.)?linkedin\.com\/in\/[A-Za-z0-9_-]+\/?$";
        public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public const string PhoneNumberPattern = @"^\+?\d{1,14}$";
    }
}
