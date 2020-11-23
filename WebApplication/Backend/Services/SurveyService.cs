using health_clinic_class_diagram.Backend.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Repositorys;

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
    }
}
