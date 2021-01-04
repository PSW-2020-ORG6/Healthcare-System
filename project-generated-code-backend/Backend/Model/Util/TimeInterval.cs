using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace HealthClinicBackend.Backend.Model.Util
{
    [Owned]
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Id { get; set; }
        public string Time => Start.ToString("HH:mm") + " - " + End.ToString("HH:mm");

        public TimeInterval()
        {
        }

        [JsonConstructor]
        public TimeInterval(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public TimeInterval(string start, string end)
        {
            Validate(start, end);
            try
            {
                Start = Convert.ToDateTime(start);
                End = Convert.ToDateTime(end);
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

        private void Validate(string start, string end)
        {
            ValidateStart(start);
            ValidateEnd(end);
        }

        private void ValidateStart(string start)
        {
            if (string.IsNullOrEmpty(start)) throw new Exception("Start is required!");
            else if (start.Length != 19) throw new Exception("Start is not correct length.");
            else if (IsDateTime(start)) throw new Exception("Start is not set as datetime.");
        }

        private void ValidateEnd(string end)
        {
            if (string.IsNullOrEmpty(end)) throw new Exception("End is required!");
            else if (end.Length != 19) throw new Exception("End is not correct length.");
            else if (IsDateTime(end)) throw new Exception("End is not set as datetime.");
        }

        private bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }
    }
}