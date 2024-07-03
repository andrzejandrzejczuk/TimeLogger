namespace TimeLogger.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        
        public string FirstName { get; set; } = default!;
        
        public string LastName { get; set; } = default!;
        
        public string Email { get; set; } = default!;
        
        public IEnumerable<Timesheet> Timesheets { get; set; } = Enumerable.Empty<Timesheet>();
    }
}
