using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Survey;
using HealthClinicBackend.Backend.Repository.Generic;
using WebApplication.Backend.Util;

namespace WebApplication.Backend.Services
{
    public class SurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        ////Marija Vucetic  RA157/2017
        /// <summary>
        ///adding new survez to database
        ///</summary>
        ///<returns>
        ///true in case of success,false otherwise
        ///</returns>
        public bool AddNewSurvey(Survey survey)
        {
            _surveyRepository.Save(survey);
            return true;
        }

        internal List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId)
        {
            return _surveyRepository.GetAll()
                .Where(s => s.Id.Equals(patientId))
                .Select(s => s.DoctorName).ToList();
        }

        internal List<string> GetAllDoctorsFromReporstByPatientIdForSurveyList(string patientId)
        {
            return new List<string>();
            // return _surveyRepository.GetAllDoctorsFromReporstByPatientIdForSurveyList(patientId);
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
            return new List<string>();
            // return _surveyRepository.GetAllDoctorsFromReporstByPatientId(patientId);
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
            return new List<StatisticAuxilaryClass>();
            // return _surveyRepository.getStatisticsEachQuestion();
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
            return new List<StatisticAuxilaryClass>();
            // return _surveyRepository.getStatisticsForDoctor(doctorID);
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
            return new List<StatisticAuxilaryClass>();
            // return _surveyRepository.getStatisticsEachTopic();
        }
    }
}