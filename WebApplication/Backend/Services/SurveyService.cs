using System;
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
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IReportRepository _reportRepository;

        public SurveyService(ISurveyRepository surveyRepository, IAppointmentRepository appointmentRepository,
            IReportRepository reportRepository)
        {
            _surveyRepository = surveyRepository;
            _appointmentRepository = appointmentRepository;
            _reportRepository = reportRepository;
        }

        /// <summary>
        ///adding new survez to database
        ///</summary>
        ///<returns>
        ///true in case of success,false otherwise
        ///</returns>
        public bool AddNewSurvey(Survey surveyText)
        {
            _surveyRepository.Save(surveyText);
            return true;
        }

        /// <summary>
        ///method for getting doctor's full name from survey done by one patient 
        ///</summary>
        ///<param name="patientId"/> String type object
        ///<returns>
        ///list of doctor's full name (string)
        ///</returns>
        internal List<string> GetAllDoctorsFromReportsByPatientIdFromSurvey(string patientId)
        {
            return _surveyRepository.GetDoctorNamesByPatientId(patientId);
        }

        /// <summary>
        ///method for getting avaliable doctors as survey subject
        ///the result is a combination of several methods
        ///</summary>
        ///<param name="patientId"/> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<string> GetAllDoctorsFromReportsByPatientIdForSurveyList(string patientId)
        {
            List<String> resultListFromSurvey =
                _surveyRepository.GetDoctorNamesByPatientId(patientId);
            List<String> resultListFromReports = _surveyRepository.GetDoctorNamesByPatientId(patientId);
            List<String> resultList = new List<String>();

            List<String> resultListPastAppointments =
                _appointmentRepository.GetByPatientId(patientId)
                    .Where(a => !a.IsSurveyDone)
                    .Select(a => a.Physician.Name + " " + a.Physician.Surname).ToList();

            foreach (String physicianFromRepors in resultListFromReports)
            {
                resultList.Add(physicianFromRepors);
            }

            foreach (String physicianFromPastAppointmentst in resultListPastAppointments)
            {
                resultList.Add(physicianFromPastAppointmentst);
            }


            foreach (String physicianFromSurvey in resultListFromSurvey)
            {
                if (resultList.Contains(physicianFromSurvey))
                {
                    resultList.Remove(physicianFromSurvey);
                }
            }

            return resultList;
        }

        /// <summary>
        ///getting all doctors from one patient's reports 
        ///</summary>
        ///<returns>
        ///list of names of doctors
        ///</returns>
        ///<param name="patientId"> String patient id
        ///</param>
        internal List<string> GetAllDoctorsFromReportsByPatientId(string patientId)
        {
            var reports = _reportRepository.GetByPatientId(patientId);
            return reports.Select(r => r.Physician.Name + " " + r.Physician.Surname).ToList();
        }

        /// <summary>
        ///calculates statistics for each survey question not related do doctor
        ///</summary>
        ///<returns>
        ///list of objects containing information about each question
        ///</returns>
        public List<StatisticAuxilaryClass> GetStatisticsEachQuestion()
        {
            var surveys = _surveyRepository.GetAll();

            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 19; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in surveys)
            {
                statistics[0].AverageRating += Double.Parse(s.Questions[4]);
                statistics[0].increment(Int32.Parse(s.Questions[4]));
                statistics[1].AverageRating += Double.Parse(s.Questions[5]);
                statistics[1].increment(Int32.Parse(s.Questions[5]));
                statistics[2].AverageRating += Double.Parse(s.Questions[6]);
                statistics[2].increment(Int32.Parse(s.Questions[6]));
                statistics[3].AverageRating += Double.Parse(s.Questions[7]);
                statistics[3].increment(Int32.Parse(s.Questions[7]));
                statistics[4].AverageRating += Double.Parse(s.Questions[8]);
                statistics[4].increment(Int32.Parse(s.Questions[8]));
                statistics[5].AverageRating += Double.Parse(s.Questions[9]);
                statistics[5].increment(Int32.Parse(s.Questions[9]));
                statistics[6].AverageRating += Double.Parse(s.Questions[10]);
                statistics[6].increment(Int32.Parse(s.Questions[10]));
                statistics[7].AverageRating += Double.Parse(s.Questions[11]);
                statistics[7].increment(Int32.Parse(s.Questions[11]));
                statistics[8].AverageRating += Double.Parse(s.Questions[12]);
                statistics[8].increment(Int32.Parse(s.Questions[12]));
                statistics[9].AverageRating += Double.Parse(s.Questions[13]);
                statistics[9].increment(Int32.Parse(s.Questions[13]));
                statistics[10].AverageRating += Double.Parse(s.Questions[14]);
                statistics[10].increment(Int32.Parse(s.Questions[14]));
                statistics[11].AverageRating += Double.Parse(s.Questions[15]);
                statistics[11].increment(Int32.Parse(s.Questions[15]));
                statistics[12].AverageRating += Double.Parse(s.Questions[16]);
                statistics[12].increment(Int32.Parse(s.Questions[16]));
                statistics[13].AverageRating += Double.Parse(s.Questions[17]);
                statistics[13].increment(Int32.Parse(s.Questions[17]));
                statistics[14].AverageRating += Double.Parse(s.Questions[18]);
                statistics[14].increment(Int32.Parse(s.Questions[18]));
                statistics[15].AverageRating += Double.Parse(s.Questions[19]);
                statistics[15].increment(Int32.Parse(s.Questions[19]));
                statistics[16].AverageRating += Double.Parse(s.Questions[20]);
                statistics[16].increment(Int32.Parse(s.Questions[20]));
                statistics[17].AverageRating += Double.Parse(s.Questions[21]);
                statistics[17].increment(Int32.Parse(s.Questions[21]));
                statistics[18].AverageRating += Double.Parse(s.Questions[22]);
                statistics[18].increment(Int32.Parse(s.Questions[22]));
            }

            for (int i = 0; i < 19; i++)
            {
                statistics[i].generatePercents();
                statistics[i].AverageRating = statistics[i].AverageRating / surveys.Count;
            }


            return Round2Decimals(statistics);
        }

        /// <summary>
        ///Helping class that rounds average values to 2 decimals
        ///</summary>
        ///<returns>
        ///list of objects containing informations about doctor related questions
        ///</returns>
        ///<param name="statistics"> String for identification of doctor
        ///</param>
        private List<StatisticAuxilaryClass> Round2Decimals(List<StatisticAuxilaryClass> statistics)
        {
            foreach (StatisticAuxilaryClass i in statistics)
            {
                i.AverageRating = Math.Round(i.AverageRating, 2);
            }

            return statistics;
        }

        /// <summary>
        ///calculates statistics for each doctor related question
        ///</summary>
        ///<returns>
        ///list of objects containing informations about doctor related questions
        ///</returns>
        ///<param name="doctorName"> String for identification of doctor
        ///</param>
        public List<StatisticAuxilaryClass> GetStatisticsForDoctor(string doctorName)
        {
            List<Survey> surveys = _surveyRepository.GetByDoctorName(doctorName);

            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 5; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in surveys)
            {
                statistics[0].AverageRating += Double.Parse(s.Questions[0]);
                statistics[0].increment(Int32.Parse(s.Questions[0]));
                statistics[1].AverageRating += Double.Parse(s.Questions[1]);
                statistics[1].increment(Int32.Parse(s.Questions[1]));
                statistics[2].AverageRating += Double.Parse(s.Questions[2]);
                statistics[2].increment(Int32.Parse(s.Questions[2]));
                statistics[3].AverageRating += Double.Parse(s.Questions[3]);
                statistics[3].increment(Int32.Parse(s.Questions[3]));
                statistics[4].AverageRating += (Double.Parse(s.Questions[3]) + Double.Parse(s.Questions[2]) +
                                                Double.Parse(s.Questions[1]) + Double.Parse(s.Questions[0]));
                statistics[4].increment(Int32.Parse(s.Questions[3]));
                statistics[4].increment(Int32.Parse(s.Questions[2]));
                statistics[4].increment(Int32.Parse(s.Questions[1]));
                statistics[4].increment(Int32.Parse(s.Questions[0]));
            }

            for (int i = 0; i < 5; i++)
            {
                statistics[i].generatePercents();

                if (i == 4)
                    statistics[i].AverageRating = statistics[i].AverageRating / surveys.Count / 4;
                else
                    statistics[i].AverageRating = statistics[i].AverageRating / surveys.Count;
            }

            return Round2Decimals(statistics);
        }

        /// <summary>
        ///calculates statistics for each topic
        ///</summary>
        ///<returns>
        ///list of objects containing information about each topic
        ///</returns>
        public List<StatisticAuxilaryClass> GetStatisticsEachTopic()
        {
            var surveys = _surveyRepository.GetAll();

            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 5; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in surveys)
            {
                statistics[0].AverageRating += Double.Parse(s.Questions[4]);
                statistics[0].increment(Int32.Parse(s.Questions[4]));
                statistics[0].AverageRating += Double.Parse(s.Questions[5]);
                statistics[0].increment(Int32.Parse(s.Questions[5]));
                statistics[0].AverageRating += Double.Parse(s.Questions[6]);
                statistics[0].increment(Int32.Parse(s.Questions[6]));
                statistics[0].AverageRating += Double.Parse(s.Questions[7]);
                statistics[0].increment(Int32.Parse(s.Questions[7]));
                statistics[0].AverageRating += Double.Parse(s.Questions[8]);
                statistics[0].increment(Int32.Parse(s.Questions[8]));
                statistics[1].AverageRating += Double.Parse(s.Questions[9]);
                statistics[1].increment(Int32.Parse(s.Questions[9]));
                statistics[1].AverageRating += Double.Parse(s.Questions[10]);
                statistics[1].increment(Int32.Parse(s.Questions[10]));
                statistics[1].AverageRating += Double.Parse(s.Questions[11]);
                statistics[1].increment(Int32.Parse(s.Questions[11]));
                statistics[1].AverageRating += Double.Parse(s.Questions[12]);
                statistics[1].increment(Int32.Parse(s.Questions[12]));
                statistics[2].AverageRating += Double.Parse(s.Questions[13]);
                statistics[2].increment(Int32.Parse(s.Questions[13]));
                statistics[2].AverageRating += Double.Parse(s.Questions[14]);
                statistics[2].increment(Int32.Parse(s.Questions[14]));
                statistics[2].AverageRating += Double.Parse(s.Questions[15]);
                statistics[2].increment(Int32.Parse(s.Questions[15]));
                statistics[2].AverageRating += Double.Parse(s.Questions[16]);
                statistics[2].increment(Int32.Parse(s.Questions[16]));
                statistics[2].AverageRating += Double.Parse(s.Questions[17]);
                statistics[2].increment(Int32.Parse(s.Questions[17]));
                statistics[3].AverageRating += Double.Parse(s.Questions[18]);
                statistics[3].increment(Int32.Parse(s.Questions[18]));
                statistics[3].AverageRating += Double.Parse(s.Questions[19]);
                statistics[3].increment(Int32.Parse(s.Questions[19]));
                statistics[4].AverageRating += Double.Parse(s.Questions[20]);
                statistics[4].increment(Int32.Parse(s.Questions[20]));
                statistics[4].AverageRating += Double.Parse(s.Questions[21]);
                statistics[4].increment(Int32.Parse(s.Questions[21]));
                statistics[4].AverageRating += Double.Parse(s.Questions[22]);
                statistics[4].increment(Int32.Parse(s.Questions[22]));
            }

            statistics[0].generatePercents();
            statistics[1].generatePercents();
            statistics[2].generatePercents();
            statistics[3].generatePercents();
            statistics[4].generatePercents();
            statistics[0].AverageRating = statistics[0].AverageRating / surveys.Count / 5;
            statistics[1].AverageRating = statistics[1].AverageRating / surveys.Count / 4;
            statistics[2].AverageRating = statistics[2].AverageRating / surveys.Count / 5;
            statistics[3].AverageRating = statistics[3].AverageRating / surveys.Count / 2;
            statistics[4].AverageRating = statistics[4].AverageRating / surveys.Count / 3;

            return Round2Decimals(statistics);
        }
    }
}