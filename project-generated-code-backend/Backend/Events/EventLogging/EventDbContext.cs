using HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Events.EventLogging
{
    public class EventDbContext : DbContext
    {
        public DbSet<PatientRegisteredEvent> PatientRegisteredEvents { get; set; }

        public EventDbContext() : base()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "userid=postgres;server=localhost;port=5432;database=healthcare-system-events;password=super;");
        }
    }
}