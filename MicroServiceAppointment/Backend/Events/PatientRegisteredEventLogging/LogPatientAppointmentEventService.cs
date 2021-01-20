using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class LogPatientAppointmentEventService : ILogEventService<PatientAppointmentEventParams>
    {
        private readonly IPatientAppointmentEventRepository _patientAppointmentEventRepository;
        public LogPatientAppointmentEventService(IPatientAppointmentEventRepository patientAppointmentEventRepository)
        {
            _patientAppointmentEventRepository = patientAppointmentEventRepository;
        }
        private List<PatientAppointmentEventDto> GetPatientAppointmentEventDto(List<PatientAppointmentEvent> appointments)
        {
            List<PatientAppointmentEventDto> appointmentsDto = new List<PatientAppointmentEventDto>();
            foreach (PatientAppointmentEvent a in appointments)
            {
                PatientAppointmentEventDto appointmentDTO = new PatientAppointmentEventDto(a);
                appointmentsDto.Add(appointmentDTO);
            }
            return appointmentsDto;
        }
       
        public void LogEvent(PatientAppointmentEventParams eventParams)
        {
            var patientAppointmentEvent = new PatientAppointmentEvent
            { TimeStamp = DateTime.Now, TransitionsFromTwoToOneStep = eventParams.TransitionsFromTwoToOneStep, 
                TransitionsFromThreeToTwoStep = eventParams.TransitionsFromThreeToTwoStep, TransitionsFromFourToThreeStep = eventParams.TransitionsFromFourToThreeStep,
                IsAppointmentScheduled = eventParams.IsAppointmentScheduled, SchedulingDuration = eventParams.SchedulingDuration};

            _patientAppointmentEventRepository.LogEvent(patientAppointmentEvent);
        }

        public List<PatientAppointmentEventDto> GetAllAppointments()
        {
            return GetPatientAppointmentEventDto(_patientAppointmentEventRepository.GetAll());
        }
    }
}
