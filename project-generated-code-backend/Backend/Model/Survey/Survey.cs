using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Util;

namespace HealthClinicBackend.Backend.Model.Survey
{
    public class Survey : Entity
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public List <String> Questions { get; set; }
        public DateTime ReportDate { get; set; }

        public Survey() : base()
        {
        }
        public Survey(String Id,String DoctorName,DateTime ReportDate)
        {
            this.Id = Id;
            this.ReportDate = ReportDate;
            this.DoctorName = DoctorName;
            Questions = new List<string>();
        }
    }
}