using HealthClinicBackend.Backend.Events.EventLogging;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientRegisteredEventDatabase : EventDatabase<PatientRegisteredEventLogging.PatientRegisteredEvent>, IPatientRegisteredEventRepository
    {
        public PatientRegisteredEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(PatientRegisteredEventLogging.PatientRegisteredEvent @event)
        {
            DbContext.PatientRegisteredEvents.Add(@event);
            DbContext.SaveChanges();
        }
    }
}