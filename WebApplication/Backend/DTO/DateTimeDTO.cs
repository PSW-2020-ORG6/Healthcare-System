using System;
using System.Collections.Generic;

namespace WebApplication.Backend.DTO
{
    public class DateTimeDTO
    {
        public DateTimeDTO()
        {
        }
        public List<DateTime> CreateDate(string dateTimesString)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            dateTimes.Add(CreateDateTime(dateTimesString.Split(";")[0]));
            dateTimes.Add(CreateDateTime(dateTimesString.Split(";")[1]));
            return dateTimes;
        }
        private DateTime CreateDateTime(string date)
        {
            return new DateTime(Convert.ToInt32(date.Split("-")[0]), Convert.ToInt32(date.Split("-")[1]), Convert.ToInt32(date.Split("-")[2]));
        }
    }
}
