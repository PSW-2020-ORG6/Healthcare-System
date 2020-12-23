using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Survey;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Repositorys
{
    public interface ISurveyRepository
    {
        public bool AddNewSurvey(Survey surveyText);
        public List<string> GetAllDoctorsFromReporstByPatientId(string patientId);
        public List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId);
        public List<Survey> GetSurveys(string sqlDml);
        public List<Survey> GetSurveysbyDoctorId(string doctorId);
        public List<Survey> GetAllSurveys();
        public List<Report> GetReports(string sqlDml);
    }
}
