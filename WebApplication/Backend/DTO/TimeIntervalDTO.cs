using HealthClinicBackend.Backend.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class TimeIntervalDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
        public TimeIntervalDTO()
        {
        }
        public TimeIntervalDTO(DateTime start)
        {
            this.Start = start;
            this.End = start.Add(new TimeSpan(0, 20, 0));
        }

        public TimeIntervalDTO(TimeInterval timeInterval)
        {
            this.Start = timeInterval.Start;
            this.End = timeInterval.End;
        }

        public List<TimeIntervalDTO> ConvertListToTimeIntervalDTO(List<TimeInterval> timeIntervals)
        {
            List<TimeIntervalDTO> timeIntervalsDTO = new List<TimeIntervalDTO>();
            foreach (TimeInterval timeInterval in timeIntervals)
                timeIntervalsDTO.Add(new TimeIntervalDTO(timeInterval));
            return timeIntervalsDTO;
        }

        public bool CompareTimeIntervals(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Hour == dateTime2.Hour && dateTime1.Minute == dateTime2.Minute;
        }

        public bool IsDateIntervalValid(DateTime dateStart, DateTime dateEnd)
        {
            return dateStart <= DateTime.Now && dateEnd >= DateTime.Now;
        } 
    }
}
