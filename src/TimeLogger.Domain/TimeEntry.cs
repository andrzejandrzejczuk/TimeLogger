namespace TimeLogger.Domain
{
    public class TimeEntry
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid TimesheetId { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public string Activity { get; set; } = default!;


        public Project Project { get; set; } = default!;
        public Timesheet Timesheet { get; set; } = default!;

    }
}
