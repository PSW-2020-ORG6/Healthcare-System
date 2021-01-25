using HealthClinicBackend.Backend.Events.EventLogging;
using System;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class LogPatientAppointmentEventService : ILogEventService<PatientAppointmentEventParams>
    {
        private readonly IPatientAppointmentEventRepository _patientAppointmentEventRepository;
        public LogPatientAppointmentEventService(IPatientAppointmentEventRepository patientAppointmentEventRepository)
        {
            _patientAppointmentEventRepository = patientAppointmentEventRepository;
        }

        public void LogEvent(PatientAppointmentEventParams eventParams)
        {
            throw new NotImplementedException();
        }
    }
}
