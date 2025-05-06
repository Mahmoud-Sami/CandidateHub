namespace CandidateHub.Domain.Entities
{
    public class TimeInterval
    {
        public int Id { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException("Start time must be less than end time");

            this.Start = start;
            this.End = end;
        }
    }
}
