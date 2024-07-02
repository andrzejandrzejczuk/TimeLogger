namespace TimeLogger.Contract.Requests
{
    public class CreateTimeEntryRequest
    {
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public Time Time { get; set; } = default!;
        public string Activity { get; set; } = default!;
    }

    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
