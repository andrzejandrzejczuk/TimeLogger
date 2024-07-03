using TimeLogger.Domain;
using Microsoft.EntityFrameworkCore;

namespace TimeLogger.Infrastructure
{
    public class TimeLoggerDbContext : DbContext
    {
        public TimeLoggerDbContext(DbContextOptions<TimeLoggerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeEntry> TimeEntries { get; set; }

        public DbSet<Timesheet> Timesheets { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.TimeEntries)
                .WithOne(e => e.Project)
                .HasForeignKey(e => e.ProjectId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Timesheets)
                .WithOne(t => t.Employee)
                .HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Timesheet>()
                .HasMany(t => t.TimeEntries)
                .WithOne(te => te.Timesheet)
                .HasForeignKey(te => te.TimesheetId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
