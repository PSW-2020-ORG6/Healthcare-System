using health_clinic_class_diagram.Backend.Model.Survey;
using System.Collections.Generic;
using WebApplication.Backend.Repositorys;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Services
{
    public class SurveyService
    {
        private ISurveyRepository isurveyRepository;
        public SurveyService()
        {
            this.isurveyRepository = new SurveyRepository();
        }
        public SurveyService(ISurveyRepository iSurveyRepository)
        {
            this.isurveyRepository = iSurveyRepository;
        }
        ////Marija Vucetic  RA157/2017
        /// <summary>
        ///adding new survez to database
        ///</summary>
        ///<returns>
        ///true in case of success,false otherwise
        ///</returns>
        public bool AddNewSurvey(Survey surveyText)
        {
            return isurveyRepository.AddNewSurvey(surveyText);
        }

        internal List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId)
        {
            return isurveyRepository.GetAllDoctorsFromReporstByPatientIdFromSurvey(patientId);
        }

        internal List<string> GetAllDoctorsFromReporstByPatientIdForSurveyList(string patientId)
        {
            return isurveyRepository.GetAllDoctorsFromReporstByPatientIdForSurveyList(patientId);
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///getting all doctors from one patient's reports 
        ///</summary>
        ///<returns>
        ///list of names of doctors
        ///</returns>
        ///<param name="idPatient"> String patient id
        ///</param>
        internal List<string> GetAllDoctorsFromReporstByPatientId(string patientId)
        {
            return isurveyRepository.GetAllDoctorsFromReporstByPatientId(patientId);
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
            return isurveyRepository.getStatisticsForDoctor(doctorID);

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
            return isurveyRepository.getStatisticsEachTopic();

        }

    }
}
