// File:    TimeInterval.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class TimeInterval

using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            try
            {
                Start = Convert.ToDateTime(start);
                End = Convert.ToDateTime(end);
            }
            catch
            {
                // ignored
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
    }
}