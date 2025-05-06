namespace CandidateHub.Application.DTOs
{
    public record TimeIntervalDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeIntervalDTO(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}
