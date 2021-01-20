using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public interface IPatientAppointmentEventRepository : IEventRepository<PatientAppointmentEvent>
    {
        List<PatientAppointmentEvent> GetAll();
    }
}
