using System;
using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Dto
{
    public abstract class SuggestedAppointmentDto
    {
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool Prior { get; set; }
    }
}
