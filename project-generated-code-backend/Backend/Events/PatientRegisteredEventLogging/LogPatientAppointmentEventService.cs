using HealthClinicBackend.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

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
            //var patientRegisteredEvent = new PatientRegisteredEvent
            //{ TimeStamp = DateTime.Now, PatientAge = eventParams.PatientAge };

            //_patientAppointmentEventRepository.LogEvent(PatientAppointmentEvent);
            throw new NotImplementedException();
        }
    }
}
