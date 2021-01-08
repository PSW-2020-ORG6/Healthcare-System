using HealthClinicBackend.Backend.Events.Model;

namespace HealthClinicBackend.Backend.Events.Repository
{
    public class PatientRegisteredEventDatabase : EventDatabase<PatientRegisteredEvent>, IPatientRegisteredEventRepository
    {
        public PatientRegisteredEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(PatientRegisteredEvent @event)
        {
            DbContext.PatientRegisteredEvents.Add(@event);
            DbContext.SaveChanges();
        }
    }
}