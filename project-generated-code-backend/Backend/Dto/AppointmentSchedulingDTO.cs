using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Dto
{
    public class AppointmentSchedulingDTO
    {
        public string Date { get; set; }
        public string TimeIntervalStart { get; set; }
        public string PhysicianId { get; set; }

        public AppointmentSchedulingDTO()
        {
        }
        public AppointmentSchedulingDTO(string date, string physicianId, string timeIntervalStart)
        {
            this.Date = date;
            this.TimeIntervalStart= timeIntervalStart;
            this.PhysicianId = physicianId;
        }

        public bool IsDataValid(string date)
        {
            string[] parts = date.Split("-");
            DateTime dateTime = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            return date != null && dateTime > DateTime.Today.AddDays(2);
        }
    }
}
