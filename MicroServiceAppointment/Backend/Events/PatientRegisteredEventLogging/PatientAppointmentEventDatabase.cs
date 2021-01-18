using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEventDatabase : EventDatabase<PatientRegisteredEventLogging.PatientAppointmentEvent>, IPatientAppointmentEventRepository
    {
        public PatientAppointmentEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
        }

        public override void LogEvent(PatientRegisteredEventLogging.PatientAppointmentEvent @event)
        {
            DbContext.PatientAppointmentEvents.Add(@event);
            DbContext.SaveChanges();
        }
    }
}
