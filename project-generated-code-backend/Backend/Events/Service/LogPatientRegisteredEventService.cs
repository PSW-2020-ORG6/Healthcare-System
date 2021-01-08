using System;
using HealthClinicBackend.Backend.Events.Dto;
using HealthClinicBackend.Backend.Events.Model;
using HealthClinicBackend.Backend.Events.Repository;

namespace HealthClinicBackend.Backend.Events.Service
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
                {TimeStamp = DateTime.Now, PatientAge = eventParams.PatientAge};

            _patientRegisteredEventRepository.LogEvent(patientRegisteredEvent);
        }
    }
}