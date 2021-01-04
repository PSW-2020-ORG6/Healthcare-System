using HealthClinicBackend.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.DTO
{
    public class SurveyDTO
    {
        private string id;
        private string doctorName;
        private List<String> questions;
        private string question1;
        private string question2;
        private string question3;
        private string question4;
        private string question5;
        private string question6;
        private string question7;
        private string question8;
        private string question9;
        private string question10;
        private string question11;
        private string question12;
        private string question13;
        private string question14;
        private string question15;
        private string question16;
        private string question17;
        private string question18;
        private string question19;
        private string question20;
        private string question22;
        private string question21;
        private string question23;
        private DateTime reportDate;


        public string ID { get => id; set => id = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string Question1 { get => question1; set => question1 = value; }
        public string Question2 { get => question2; set => question2 = value; }
        public string Question3 { get => question3; set => question3 = value; }
        public string Question4 { get => question4; set => question4 = value; }
        public string Question5 { get => question5; set => question5 = value; }
        public string Question6 { get => question6; set => question6 = value; }
        public string Question7 { get => question7; set => question7 = value; }
        public string Question8 { get => question8; set => question8 = value; }
        public string Question9 { get => question9; set => question9 = value; }
        public string Question10 { get => question10; set => question10 = value; }
        public string Question11 { get => question11; set => question11 = value; }
        public string Question12 { get => question12; set => question12 = value; }
        public string Question13 { get => question13; set => question13 = value; }
        public string Question14 { get => question14; set => question14 = value; }
        public string Question15 { get => question15; set => question15 = value; }
        public string Question16 { get => question16; set => question16 = value; }
        public string Question17 { get => question17; set => question17 = value; }
        public string Question18 { get => question18; set => question18 = value; }
        public string Question19 { get => question19; set => question19 = value; }
        public string Question20 { get => question20; set => question20 = value; }
        public string Question22 { get => question22; set => question22 = value; }
        public string Question21 { get => question21; set => question21 = value; }
        public string Question23 { get => question23; set => question23 = value; }
        public List<String> Questions { get => questions; set => questions = value; }
        public DateTime ReportDate { get => reportDate; set => reportDate = value; }

        public SurveyDTO() { }
        public SurveyDTO(Survey survey)
        {
            id = survey.PatientId;
            doctorName = survey.DoctorName;
            ReportDate = survey.ReportDate;
        }

            public List<SurveyDTO> ConvertListToSurveyDTO(List<Survey> surveys)
            {
                List<SurveyDTO> surveysDTO = new List<SurveyDTO>();
                foreach (Survey survey in surveys)
                    surveysDTO.Add(new SurveyDTO(survey));
                return surveysDTO;
            }
    }
}
