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
        private string id;
        public string time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
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
            this.Id = timeInterval.Id;
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

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
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
    }
}
