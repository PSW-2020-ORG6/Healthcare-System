using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEventDatabase : EventDatabase<PatientAppointmentEvent>, IPatientAppointmentEventRepository
    {

        public PatientAppointmentEventDatabase(EventDbContext dbContext) : base(dbContext)
        {
        }


        public override void LogEvent(PatientAppointmentEvent @event)
        {
            DbContext.PatientAppointmentEvents.Add(@event);
            DbContext.SaveChanges();
        }

        List<PatientAppointmentEvent> IPatientAppointmentEventRepository.GetAll()
        {
            return DbContext.PatientAppointmentEvents.ToList();
        }
    }
}
