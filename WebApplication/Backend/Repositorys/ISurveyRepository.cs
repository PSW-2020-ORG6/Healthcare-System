using health_clinic_class_diagram.Backend.Model.Survey;
using System.Collections.Generic;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Repositorys
{
    public interface ISurveyRepository
    {
        public bool AddNewSurvey(Survey surveyText);
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion();
        List<StatisticAuxilaryClass> getStatisticsEachTopic();
        List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorID);
        public List<string> GetAllDoctorsFromReporstByPatientId(string patientId);
        public List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId);
        public List<string> GetAllDoctorsFromReporstByPatientIdForSurveyList(string patientId);
    }
}
