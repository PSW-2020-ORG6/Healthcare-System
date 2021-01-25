using HealthClinicBackend.Backend.Events.EventLogging;
using System;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class LogPatientRegisteredEventService : ILogEventService<PatientRegisteredEventParams>
    {
        private readonly IPatientRegisteredEventRepository _patientRegisteredEventRepository;

        public LogPatientRegisteredEventService(IPatientRegisteredEventRepository patientRegisteredEventRepository)
        {
            _patientRegisteredEventRepository = patientRegisteredEventRepository;
        }

        public void LogEvent(PatientRegisteredEventParams eventParams)
        {
            var patientRegisteredEvent = new PatientRegisteredEvent
            { TimeStamp = DateTime.Now, PatientAge = eventParams.PatientAge };

            _patientRegisteredEventRepository.LogEvent(patientRegisteredEvent);
        }
    }
}