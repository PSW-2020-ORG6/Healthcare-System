using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class EventStatisticDTO
    {
        public double PercentTransitionsToFirstStepOnce { get; set; }
        public double PercentTransitionsToFirstStepTwice { get; set; }
        public double PercentTransitionsToFirstStepMore { get; set; }

        public double PercentTransitionsToSecondStepOnce { get; set; }
        public double PercentTransitionsToSecondStepTwice { get; set; }
        public double PercentTransitionsToSecondStepMore { get; set; }

        public double PercentTransitionsToThirdStepOnce { get; set; }
        public double PercentTransitionsToThirdStepTwice { get; set; }
        public double PercentTransitionsToThirdStepMore { get; set; }

        public string SchedulingDuration { get; set; }

        public double PercentIsAppointmentScheduled { get; set; }
        public double PercentIsNotAppointmentScheduled { get; set; }

        public double PercenttTransitionsToFirstStep { get; set; }
        public double PercenttTransitionsToSecondStep { get; set; }
        public double PercenttTransitionsToThirdStep { get; set; }

        public EventStatisticDTO()
        {
        }

         public EventStatisticDTO(string duration)
        {
            SchedulingDuration = duration;
        }
    }
}
