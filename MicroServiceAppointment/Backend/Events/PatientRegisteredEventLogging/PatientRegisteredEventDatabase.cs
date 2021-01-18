using MicroServiceAppointment.Backend.Events.EventLogging;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
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