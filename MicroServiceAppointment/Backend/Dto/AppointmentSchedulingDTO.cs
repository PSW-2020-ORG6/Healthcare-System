using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceAppointment.Backend.Dto
{
    public class AppointmentSchedulingDTO
    {
        public string Date { get; set; }
        public string TimeIntervalStart { get; set; }
        public string TimeIntervalEnd { get; set; }
        public string PhysicianId { get; set; }
        public string PatientId { get; set; }

        public AppointmentSchedulingDTO()
        {
        }
        public AppointmentSchedulingDTO(string date, string physicianId, string timeIntervalStart, string patientId, string timeIntervalEnd)
        {
            this.Date = date;
            this.TimeIntervalStart = timeIntervalStart;
            this.TimeIntervalEnd = timeIntervalEnd;
            this.PhysicianId = physicianId;
            this.PatientId = patientId;
        }

        public bool IsDataValid(string date)
        {
            string[] parts = date.Split("-");
            DateTime dateTime = new DateTime(Int32.Parse(parts[0]), Int32.Parse(parts[1]), Int32.Parse(parts[2]), 0, 0, 0);
            return date != null && dateTime > DateTime.Today.AddDays(2);
        }
    }
}
