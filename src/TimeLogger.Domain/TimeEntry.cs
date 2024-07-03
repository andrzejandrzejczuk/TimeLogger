namespace TimeLogger.Domain
{
    public class TimeEntry
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; } = default!;

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public string Activity { get; set; } = default!;
    }
}
