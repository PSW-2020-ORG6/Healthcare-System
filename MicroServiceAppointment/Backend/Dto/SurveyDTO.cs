using MicroServiceAppointment.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAppointment.Backend.Dto
{
    public class SurveyDto
    {
        public string PatientId { get; set; }
        public string DoctorName { get; set; }
        public List<String> Questions { get; set; }
        public DateTime ReportDate { get; set; }

        public SurveyDto() { }
        public SurveyDto(string patientId, string doctorName, DateTime reportDate)
        {
            PatientId = patientId;
            DoctorName = doctorName;
            ReportDate = reportDate;
            Questions = new List<string>();
        }
        public SurveyDto(Survey survey)
        {
            PatientId = survey.PatientId;
            DoctorName = survey.DoctorName;
            ReportDate = survey.ReportDate;
            Questions = survey.Questions;
        }
    }
}
