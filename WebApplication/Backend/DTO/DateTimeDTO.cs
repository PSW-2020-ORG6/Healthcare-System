using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            string dateFrom = dateTimesString.Split(";")[0];
            string dateTo = dateTimesString.Split(";")[1];
            dateTimes.Add(new DateTime(Convert.ToInt32(dateFrom.Split("-")[0]), Convert.ToInt32(dateFrom.Split("-")[1]), Convert.ToInt32(dateFrom.Split("-")[2])));
            dateTimes.Add(new DateTime(Convert.ToInt32(dateTo.Split("-")[0]), Convert.ToInt32(dateTo.Split("-")[1]), Convert.ToInt32(dateTo.Split("-")[2])));
            return dateTimes;
        }
    }
}
