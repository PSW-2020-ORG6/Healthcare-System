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

        ////Aleksa Repovic RA52/2017
        /// <summary>
        ///calculates statistics for each survey question not related do doctor
        ///</summary>
        ///<returns>
        ///list of objects containing information about each question
        ///</returns>
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {
            return isurveyRepository.getStatisticsEachQuestion();
        }

        ////Repovic Aleksa RA52/2017
        /// <summary>
        ///calculates statistics for each doctor related question
        ///</summary>
        ///<returns>
        ///list of objects containing informations about doctor related questions
        ///</returns>
        ///<param name="doctorId"> String for identification of doctor
        ///</param>
        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorID)
        {
            return surveyRepository.getStatisticsForDoctor(doctorID);

        }

        ////Aleksa Repovic RA52/2017
        /// <summary>
        ///calculates statistics for each topic
        ///</summary>
        ///<returns>
        ///list of objects containing information about each topic
        ///</returns>
        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {
            return surveyRepository.getStatisticsEachTopic();

        }

    }
}
