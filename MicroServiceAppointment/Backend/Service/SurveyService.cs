using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Survey;
using MicroServiceAppointment.Backend.Repository.Generic;
using MicroServiceAppointment.Backend.Util;

namespace MicroServiceAppointment.Backend.Service
{
    public class SurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public SurveyService(ISurveyRepository surveyRepository, IAppointmentRepository appointmentRepository)
        {
            _surveyRepository = surveyRepository;
            _appointmentRepository = appointmentRepository;
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
            var appointmentDtos = HttpRequest.GetAllAppointmentsByPatientIdDateAndDoctor(surveyText.PatientId, surveyText.ReportDate.ToString(), surveyText.DoctorName).Result;
            HttpRequest.UpdateAppointment(appointmentDtos[0]);
            return true;
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
            List<String> resultList = new List<String>();
            List<String> resultListPastAppointments = new List<String>();

            foreach (Appointment a in _appointmentRepository.GetDoneSurveyByPatentId(patientId))
            {
                resultListPastAppointments.Add(HttpRequest.GetPhysiciantByIdAsync(a.PhysicianSerialNumber).Result.FullName + "-" + a.Date.ToString().Split(" ")[0]);
                if (a.Date > DateTime.Now)
                    resultListPastAppointments.Remove(HttpRequest.GetPhysiciantByIdAsync(a.PhysicianSerialNumber).Result.FullName + "-" + a.Date.ToString().Split(" ")[0]);
            }
            foreach (String physicianFromPastAppointmentst in resultListPastAppointments)
                resultList.Add(physicianFromPastAppointmentst);

            foreach (String physicianFromSurvey in resultListFromSurvey)
                if (resultList.Contains(physicianFromSurvey)) resultList.Remove(physicianFromSurvey);
            return resultList;
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
                statistics.Add(new StatisticAuxilaryClass());
            foreach (Survey s in surveys)
            {
                for (int i = 0; i < 19; i++) {
                    statistics[i].AverageRating += Double.Parse(s.Questions[4 + i]);
                    statistics[i].increment(Int32.Parse(s.Questions[4 + i]));
                }
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
                i.AverageRating = Math.Round(i.AverageRating, 2);
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
                statistics.Add(new StatisticAuxilaryClass());

            foreach (Survey s in surveys)
            {
                for (int i = 0; i < 4; i++) {
                    statistics[i].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[i].increment(Int32.Parse(s.Questions[i]));

                }
                for (int i = 0; i < 4; i++)
                    statistics[4].increment(Int32.Parse(s.Questions[i]));

                statistics[4].AverageRating += (Double.Parse(s.Questions[3]) + Double.Parse(s.Questions[2]) +
                                                Double.Parse(s.Questions[1]) + Double.Parse(s.Questions[0]));
            }
            for (int i = 0; i < 5; i++)
            {
                statistics[i].generatePercents();
                if (i == 4) statistics[i].AverageRating = statistics[i].AverageRating / surveys.Count / 4;
                else statistics[i].AverageRating = statistics[i].AverageRating / surveys.Count;
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
                for (int i = 4; i <= 8; i++)
                {
                    statistics[0].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[0].increment(Int32.Parse(s.Questions[i]));
                }
                for (int i = 9; i <= 12; i++)
                {
                    statistics[1].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[1].increment(Int32.Parse(s.Questions[i]));
                }
                for (int i = 13; i <= 17; i++)
                {
                    statistics[2].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[2].increment(Int32.Parse(s.Questions[i]));
                }
                for (int i = 18; i <= 19; i++)
                {
                    statistics[3].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[3].increment(Int32.Parse(s.Questions[i]));
                }
                for (int i = 20; i <= 22; i++)
                {
                    statistics[4].AverageRating += Double.Parse(s.Questions[i]);
                    statistics[4].increment(Int32.Parse(s.Questions[i]));
                }
            }
            for (int i = 0;  i <= 4; i++) 
                statistics[i].generatePercents();

            statistics[0].AverageRating = statistics[0].AverageRating / surveys.Count / 5;
            statistics[1].AverageRating = statistics[1].AverageRating / surveys.Count / 4;
            statistics[2].AverageRating = statistics[2].AverageRating / surveys.Count / 5;
            statistics[3].AverageRating = statistics[3].AverageRating / surveys.Count / 2;
            statistics[4].AverageRating = statistics[4].AverageRating / surveys.Count / 3;

            return Round2Decimals(statistics);
        }
    }
}