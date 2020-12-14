using System;
using System.Collections.Generic;

namespace WebApplication.Backend.DTO
{
    public class DateFromStringConverter
    {
        public DateFromStringConverter()
        {
        }

        public List<DateTime> CreateDate(string dateTimesString)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            dateTimes.Add(CreateDateTime(dateTimesString.Split(";")[0]));
            dateTimes.Add(CreateDateTime(dateTimesString.Split(";")[1]));
            return dateTimes;
        }

        public DateTime CreateDateTime(string date)
        {
            string[] dates = date.Split("-");
            return new DateTime(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2]));
        }
        public bool IsPreferredTimeValid(string date)
        {
            return DateTime.Parse(date) > DateTime.Today.AddDays(2);
        }

        internal bool IsPreferredTimeIntervalValid(string dates)
        {
            string[] d = dates.Split(",");
            foreach (string date in d)
            {
                if (!IsPreferredTimeValid(date))
                    return false;
            }
            return true;
        }

        public string[] DateGeneration(string dates)
        {
            return dates.Split(",");
        }
    }
}
