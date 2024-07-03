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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(p => p.TimeEntries)
                .WithOne(e => e.Project)
                .HasForeignKey(e => e.ProjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
