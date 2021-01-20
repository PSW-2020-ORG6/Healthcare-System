using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEventDto
    {
        public int TransitionsFromTwoToOneStep { get; set; }
        public int TransitionsFromThreeToTwoStep { get; set; }
        public int TransitionsFromFourToThreeStep { get; set; }
        public string SchedulingDuration { get; set; }
        public bool IsAppointmentScheduled { get; set; }

        public PatientAppointmentEventDto() { }
        public PatientAppointmentEventDto(PatientAppointmentEvent patientAppointmentEvent)
        {
            TransitionsFromTwoToOneStep = patientAppointmentEvent.TransitionsFromTwoToOneStep;
            TransitionsFromThreeToTwoStep = patientAppointmentEvent.TransitionsFromThreeToTwoStep;
            TransitionsFromFourToThreeStep = patientAppointmentEvent.TransitionsFromFourToThreeStep;
            SchedulingDuration = patientAppointmentEvent.SchedulingDuration;
            IsAppointmentScheduled = patientAppointmentEvent.IsAppointmentScheduled;
        }
        public List<PatientAppointmentEventDto> ConvertListToPatientAppointmentEventDto(List<PatientAppointmentEvent> patientAppointmentEventDtos)
        {
            List<PatientAppointmentEventDto> appointmentsDTO = new List<PatientAppointmentEventDto>();
            if (patientAppointmentEventDtos == null)
                return appointmentsDTO;
            foreach (PatientAppointmentEvent appointment in patientAppointmentEventDtos)
                appointmentsDTO.Add(new PatientAppointmentEventDto(appointment));
            return appointmentsDTO;
        }
    }
}
