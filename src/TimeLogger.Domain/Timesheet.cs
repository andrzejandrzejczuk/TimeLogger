namespace TimeLogger.Domain
{
    public class Timesheet
    {
        public Guid Id { get; set; }
        
        public int EmployeeId { get; set; }
        
        public DateTime Month { get; set; } 
        
        public bool IsSubmitted { get; set; }


        public Employee Employee { get; set; } = default!;
        
        public IEnumerable<TimeEntry> TimeEntries { get; set; } = Enumerable.Empty<TimeEntry>();
    }
}
