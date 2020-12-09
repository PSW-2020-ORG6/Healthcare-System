using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class TimeIntervalFilter
    {
        public List<TimeInterval> FilterByDate(List<TimeInterval> timeIntervals, DateTime date)
        {
            List<TimeInterval> filteredTimeIntervals = new List<TimeInterval>();
            foreach (TimeInterval ti in timeIntervals)
            {
                if (date.Equals(ti.Start.Date))
                {
                    filteredTimeIntervals.Add(ti);
                }
            }
            return filteredTimeIntervals;
        }
        public List<TimeInterval> FilterByTime(List<TimeInterval> timeIntervals, TimeInterval time)
        {
            List<TimeInterval> filteredTimeIntervals = new List<TimeInterval>();
            foreach (TimeInterval ti in timeIntervals)
            {
                if (ti.TimeOfDayEquals(time))
                {
                    filteredTimeIntervals.Add(ti);
                }
            }
            return filteredTimeIntervals;
        }
    }
}
