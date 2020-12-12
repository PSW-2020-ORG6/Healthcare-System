using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class TimeIntervalDTO
    {
        private DateTime start;
        private DateTime end;
        public string time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
        public TimeIntervalDTO()
        {
        }

        public TimeIntervalDTO(TimeInterval timeInterval)
        {
            this.Start = timeInterval.Start;
            this.End = timeInterval.End;
        }

        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }


        public List<TimeIntervalDTO> ConvertListToTimeIntervalDTO(List<TimeInterval> timeIntervals)
        {
            List<TimeIntervalDTO> timeIntervalsDTO = new List<TimeIntervalDTO>();
            foreach (TimeInterval timeInterval in timeIntervals)
                timeIntervalsDTO.Add(new TimeIntervalDTO(timeInterval));
            return timeIntervalsDTO;
        }
    }
}
