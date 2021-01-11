using MicroServiceAccount.Backend.Model.Util;
using MicroServiceAppointment.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class TimeIntervalsDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
        public TimeIntervalsDTO()
        {
        }
        public TimeIntervalsDTO(DateTime start)
        {
            this.Start = start;
            this.End = start.Add(new TimeSpan(0, 20, 0));
        }

        public TimeIntervalsDTO(TimeInterval timeInterval)
        {
            this.Start = timeInterval.Start;
            this.End = timeInterval.End;
        }

        public List<TimeIntervalsDTO> ConvertListToTimeIntervalDTO(List<TimeInterval> timeIntervals)
        {
            List<TimeIntervalsDTO> timeIntervalsDTO = new List<TimeIntervalsDTO>();
            foreach (TimeInterval timeInterval in timeIntervals)
                timeIntervalsDTO.Add(new TimeIntervalsDTO(timeInterval));
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
