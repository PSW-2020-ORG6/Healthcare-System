using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Events.PatientRegisteredEventLogging
{
    public class PatientAppointmentEvent:EventLogging.Event
    {
        public int TransitionsFromTwoToOneStep { get; set; }
        public int TransitionsFromThreeToTwoStep { get; set; }
        public int TransitionsFromFourToThreeStep { get; set; }
        public int SchedulingDuration { get; set; }
        public bool isAppointmentScheduled { get; set; }
    }
}
