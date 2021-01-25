using HealthClinicBackend.Backend.Events.EventBuildingSelection;
using HealthClinicBackend.Backend.Events.EventFloorChange;
using HealthClinicBackend.Backend.Events.EventRoomSelection;
using HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Events.EventLogging
{
    public class EventDbContext : DbContext
    {
        public DbSet<PatientRegisteredEvent> PatientRegisteredEvents { get; set; }
        public DbSet<PatientAppointmentEvent> PatientAppointmentEvents { get; set; }
        public DbSet<RoomSelectionEvent> RoomSelectionEvents { get; set; }
        public DbSet<FloorChangeEvent> FloorChangeEvents { get; set; }
        public DbSet<BuildingSelectionEvent> BuildingSelectionEvents { get; set; }

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