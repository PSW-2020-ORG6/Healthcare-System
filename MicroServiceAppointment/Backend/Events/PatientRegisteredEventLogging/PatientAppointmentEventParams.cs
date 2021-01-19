using MicroServiceAppointment.Backend.Events.EventLogging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEventParams: EventParams
    {
        public int TransitionsFromTwoToOneStep { get; set; }
        public int TransitionsFromThreeToTwoStep { get; set; }
        public int TransitionsFromFourToThreeStep { get; set; }
        public string SchedulingDuration { get; set; }
        public bool IsAppointmentScheduled { get; set; }
        public string ChoosenPhysician { get; set; }
        public string ChoosenSpecialization { get; set; }
        public PatientAppointmentEventParams() { }
        public PatientAppointmentEventParams(int tfttos,int tfttts,int tfftts1,string sd,bool ias,string cph,string cs)
        {
            TransitionsFromTwoToOneStep = tfttos;
            TransitionsFromThreeToTwoStep = tfttts;
            TransitionsFromFourToThreeStep = tfftts1;
            SchedulingDuration = sd;
            IsAppointmentScheduled = ias;
            ChoosenPhysician = cph;
            ChoosenSpecialization = cs;
        }

    }
}
