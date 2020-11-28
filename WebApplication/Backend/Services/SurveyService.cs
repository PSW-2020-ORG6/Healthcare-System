using health_clinic_class_diagram.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Services
{
    public class SurveyService
    {
        private SurveyRepository surveyRepository;
        private ISurveyRepository isurveyRepository = new SurveyRepository();
        public SurveyService()
        {
            this.surveyRepository = new SurveyRepository();
        }
        public SurveyService(ISurveyRepository iSurveyRepository)
        {
            this.isurveyRepository = iSurveyRepository;
        }

        public bool AddNewSurvey(Survey surveyText)
        {
            return isurveyRepository.AddNewSurvey(surveyText);
        }

        internal List<string> GetAllDoctorsFromReporstByPatientId(string patientId)
        {
            return surveyRepository.GetAllDoctorsFromReporstByPatientId(patientId);
        }


        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {
            return isurveyRepository.getStatisticsEachQuestion();
        }

        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorID)
        {
            return surveyRepository.getStatisticsForDoctor(doctorID);

        }
        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {
            return surveyRepository.getStatisticsEachTopic();

        }

    }
}
