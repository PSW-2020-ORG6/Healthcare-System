using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public interface IPatientAppointmentEventRepository : IEventRepository<PatientAppointmentEvent>
    {
    }
}
