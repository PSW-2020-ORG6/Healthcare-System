using System;
using System.Collections.Generic;
using MicroServiceAccount.Backend.Model.Util;

namespace MicroServiceAppointment.Backend.Model.Survey
{
    public class Survey : Entity
    {
        public string PatientId { get; set; }
        public string DoctorName { get; set; }
        public List<String> Questions { get; set; }
        public DateTime ReportDate { get; set; }

        public Survey() : base()
        {
        }
        public Survey(string patientId, string doctorName, DateTime reportDate)
        {
            PatientId = patientId;
            DoctorName = doctorName;
            ReportDate = reportDate;
            Questions = new List<string>();
        }
    }
}