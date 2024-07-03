namespace TimeLogger.Domain
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public IEnumerable<TimeEntry> TimeEntries { get; set; } = Enumerable.Empty<TimeEntry>();
    }
}
