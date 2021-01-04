using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace HealthClinicBackend.Backend.Model.Util
{
    [Owned]
    public class TimeInterval
    {
        public string _id;
        public DateTime _start;
        public DateTime _end;
        public DateTime Start => _start;
        public DateTime End => _end;
        public string Id => _id;
        public string Time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");

        public TimeInterval()
        {
        }

        [JsonConstructor]
        public TimeInterval(DateTime start, DateTime end)
        {
            Validate(start, end);
            _start = start;
            _end = end;
        }

        public TimeInterval(string start, string end)
        {
            Validate(start, end);
            try
            {
                _start = Convert.ToDateTime(start);
                _end = Convert.ToDateTime(end);
            }
            catch
            {
                throw new Exception("Date and time couldn't be converted.");
            }
        }

        public override bool Equals(object obj)
        {
            TimeInterval other = obj as TimeInterval;
            if (other == null)
            {
                return false;
            }

            return Start.Equals(other.Start) && End.Equals(other.End);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");
        }

        public string ToStringHours()
        {
            return "start: " + Start.ToString("HH:mm") + "\nend: " + End.ToString("HH:mm");
        }

        public bool IsOverLapping(TimeInterval other)
        {
            bool condition1 = other.Start.CompareTo(End) < 0 && other.End.CompareTo(Start) > 0;
            bool condition2 = Start.CompareTo(other.End) < 0 && End.CompareTo(other.Start) > 0;
            return condition1 || condition2;
        }

        public bool IsTimeOfDayContained(TimeInterval other)
        {
            int thisStart = Start.Hour * 60 + Start.Minute;
            int thisEnd = End.Hour * 60 + End.Minute;
            if (thisEnd < thisStart)
            {
                thisEnd += 24 * 60;
            }

            int otherStart = other.Start.Hour * 60 + other.Start.Minute;
            int otherEnd = other.End.Hour * 60 + other.End.Minute;
            if (otherEnd < otherStart)
            {
                otherEnd += 24 * 60;
            }

            return thisStart <= otherStart && thisEnd >= otherEnd;
        }

        public bool TimeOfDayEquals(TimeInterval other)
        {
            return Start.TimeOfDay.Equals(other.Start.TimeOfDay) && End.TimeOfDay.Equals(other.End.TimeOfDay);
        }

        private void Validate(DateTime start, DateTime end)
        {
            ValidateDateTime(start);
            ValidateDateTime(end);
        }

        private void Validate(string start, string end)
        {
            ValidateDateTime(start);
            ValidateDateTime(end);
        }

        private void ValidateDateTime(DateTime dateTime)
        {
            if (dateTime == null) throw new Exception("Date time is required!");
            ValidateDate(dateTime);
            ValidateTime(dateTime);
        }

        private void ValidateDate(DateTime dateTime)
        {
            if (dateTime.Date.Day < 1 || dateTime.Date.Day > 31) throw new Exception("Day is not correct.");
            else if (dateTime.Date.Month < 1 || dateTime.Date.Month > 12) throw new Exception("Month is not correct.");
            else if (dateTime.Date.Year < 1 || dateTime.Date.Day > 2100) throw new Exception("Year is not correct.");
        }

        private void ValidateTime(DateTime dateTime)
        {
            if (dateTime.Hour < 0 || dateTime.Hour > 23) throw new Exception("Hour is not correct.");
            else if (dateTime.Minute < 0 || dateTime.Minute > 59) throw new Exception("Minute is not correct.");
            else if (dateTime.Second < 0 || dateTime.Second > 59) throw new Exception("Second is not correct.");
        }

        private void ValidateDateTime(string dateTime)
        {
            if (string.IsNullOrEmpty(dateTime)) throw new Exception("Date time is required!");
            else if (dateTime.Length != 19) throw new Exception("Date time is not correct length.");
            else if (IsDateTime(dateTime)) throw new Exception("Date time is not set correct.");
        }

        private bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }
    }
}