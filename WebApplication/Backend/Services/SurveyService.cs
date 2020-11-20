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
        public SurveyService()
        {
            this.surveyRepository = new SurveyRepository();
        }

        internal bool AddNewSurvey(String survey)
        {
            return surveyRepository.AddNewSurvey(survey);
        }

        internal List<string> GetAllDoctorsFromReporstByPatientId(string patientId)
        {
            return surveyRepository.GetAllDoctorsFromReporstByPatientId(patientId);
        }
    }
}
