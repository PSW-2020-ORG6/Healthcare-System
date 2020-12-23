using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Survey;
using Model.Accounts;
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

        /// <summary>
        ///method for getting doctor's full name from survey done by one patient 
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of doctor's full name (string)
        ///</returns>
        internal List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId)
        {
            return isurveyRepository.GetAllDoctorsFromReporstByPatientIdFromSurvey(patientId);
        }

        /// <summary>
        ///method for getting avaliable doctors as survey subject
        ///the result is a combination of several methods
        ///</summary>
        ///<param name="patientId"> String type object
        ///<returns>
        ///list of appointments
        ///</returns>
        internal List<string> GetAllDoctorsFromReporstByPatientIdForSurveyList(string patientId)
        {
            List<String> resultListFromSurvey = isurveyRepository.GetAllDoctorsFromReporstByPatientIdFromSurvey(patientId);
            List<String> resultListFromReports = isurveyRepository.GetAllDoctorsFromReporstByPatientId(patientId);
            List<String> resultList = new List<String>();
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<String> resultListPastAppointments = appointmentRepository.GetAllDoctorsFromAppointmentsWithoutSurvey(patientId);

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
        ///<param name="idPatient"> String patient id
        ///</param>
        internal List<string> GetAllDoctorsFromReporstByPatientId(string patientId)
        {
            List<Report> reports = isurveyRepository.GetReports("Select * from report where PatientId like'" + patientId.ToString() + "'");
            List<String> resulList = new List<String>();
            foreach (Report r in reports)
            {
                PhysicianRepository phisitionRepository = new PhysicianRepository();
                List<Physician> physitians = phisitionRepository.GetPhysiciansByFullName(r.Physician.Name + " " + r.Physician.Surname);
                foreach (Physician p in physitians)
                {
                    r.Physician.Name = p.Name;
                    r.Physician.Surname = p.Surname;
                    resulList.Add(r.Physician.Name + " " + r.Physician.Surname + "-" + r.Date.ToString().Split(" ")[0]);
                }
            }
            return resulList;
            
        }

        /// <summary>
        ///calculates statistics for each survey question not related do doctor
        ///</summary>
        ///<returns>
        ///list of objects containing information about each question
        ///</returns>
        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {
            List<Survey> reports = new List<Survey>();
            reports = isurveyRepository.GetAllSurveys();

            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 19; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in reports)
            {
                statistics[0].AverageRating += Double.Parse(s.Question5);
                statistics[0].increment(Int32.Parse(s.Question5));
                statistics[1].AverageRating += Double.Parse(s.Question6);
                statistics[1].increment(Int32.Parse(s.Question6));
                statistics[2].AverageRating += Double.Parse(s.Question7);
                statistics[2].increment(Int32.Parse(s.Question7));
                statistics[3].AverageRating += Double.Parse(s.Question8);
                statistics[3].increment(Int32.Parse(s.Question8));
                statistics[4].AverageRating += Double.Parse(s.Question9);
                statistics[4].increment(Int32.Parse(s.Question9));
                statistics[5].AverageRating += Double.Parse(s.Question10);
                statistics[5].increment(Int32.Parse(s.Question10));
                statistics[6].AverageRating += Double.Parse(s.Question11);
                statistics[6].increment(Int32.Parse(s.Question11));
                statistics[7].AverageRating += Double.Parse(s.Question12);
                statistics[7].increment(Int32.Parse(s.Question12));
                statistics[8].AverageRating += Double.Parse(s.Question13);
                statistics[8].increment(Int32.Parse(s.Question13));
                statistics[9].AverageRating += Double.Parse(s.Question14);
                statistics[9].increment(Int32.Parse(s.Question14));
                statistics[10].AverageRating += Double.Parse(s.Question15);
                statistics[10].increment(Int32.Parse(s.Question15));
                statistics[11].AverageRating += Double.Parse(s.Question16);
                statistics[11].increment(Int32.Parse(s.Question16));
                statistics[12].AverageRating += Double.Parse(s.Question17);
                statistics[12].increment(Int32.Parse(s.Question17));
                statistics[13].AverageRating += Double.Parse(s.Question18);
                statistics[13].increment(Int32.Parse(s.Question18));
                statistics[14].AverageRating += Double.Parse(s.Question19);
                statistics[14].increment(Int32.Parse(s.Question19));
                statistics[15].AverageRating += Double.Parse(s.Question20);
                statistics[15].increment(Int32.Parse(s.Question20));
                statistics[16].AverageRating += Double.Parse(s.Question21);
                statistics[16].increment(Int32.Parse(s.Question21));
                statistics[17].AverageRating += Double.Parse(s.Question22);
                statistics[17].increment(Int32.Parse(s.Question22));
                statistics[18].AverageRating += Double.Parse(s.Question23);
                statistics[18].increment(Int32.Parse(s.Question23));
            }

            for (int i = 0; i < 19; i++)
            {
                statistics[i].generatePercents();
                statistics[i].AverageRating = statistics[i].AverageRating / reports.Count;
            }


            return Round2Decimals(statistics);
        }

        /// <summary>
        ///Helping class that rounds average values to 2 decimals
        ///</summary>
        ///<returns>
        ///list of objects containing informations about doctor related questions
        ///</returns>
        ///<param name="doctorId"> String for identification of doctor
        ///</param>
        public List<StatisticAuxilaryClass> Round2Decimals(List<StatisticAuxilaryClass> statistics) { 

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
    ///<param name="doctorId"> String for identification of doctor
    ///</param>
    public List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorID)
        {
            List<Survey> reports = isurveyRepository.GetSurveysbyDoctorId(doctorID);
          
            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 5; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in reports)
            {
                statistics[0].AverageRating += Double.Parse(s.Question1);
                statistics[0].increment(Int32.Parse(s.Question1));
                statistics[1].AverageRating += Double.Parse(s.Question2);
                statistics[1].increment(Int32.Parse(s.Question2));
                statistics[2].AverageRating += Double.Parse(s.Question3);
                statistics[2].increment(Int32.Parse(s.Question3));
                statistics[3].AverageRating += Double.Parse(s.Question4);
                statistics[3].increment(Int32.Parse(s.Question4));
                statistics[4].AverageRating += (Double.Parse(s.Question4) + Double.Parse(s.Question3) +
                                                Double.Parse(s.Question2) + Double.Parse(s.Question1));
                statistics[4].increment(Int32.Parse(s.Question4));
                statistics[4].increment(Int32.Parse(s.Question3));
                statistics[4].increment(Int32.Parse(s.Question2));
                statistics[4].increment(Int32.Parse(s.Question1));
            }

            for (int i = 0; i < 5; i++)
            {
                statistics[i].generatePercents();

                if (i == 4)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count / 4;
                else
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count;
            }

            return Round2Decimals(statistics);

        }

        /// <summary>
        ///calculates statistics for each topic
        ///</summary>
        ///<returns>
        ///list of objects containing information about each topic
        ///</returns>
        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {
            List<Survey> reports = new List<Survey>();
            reports = isurveyRepository.GetAllSurveys();

            List<StatisticAuxilaryClass> statistics = new List<StatisticAuxilaryClass>();
            for (int i = 0; i < 5; i++)
            {
                statistics.Add(new StatisticAuxilaryClass());
            }

            foreach (Survey s in reports)
            {
                statistics[0].AverageRating += Double.Parse(s.Question5);
                statistics[0].increment(Int32.Parse(s.Question5));
                statistics[0].AverageRating += Double.Parse(s.Question6);
                statistics[0].increment(Int32.Parse(s.Question6));
                statistics[0].AverageRating += Double.Parse(s.Question7);
                statistics[0].increment(Int32.Parse(s.Question7));
                statistics[0].AverageRating += Double.Parse(s.Question8);
                statistics[0].increment(Int32.Parse(s.Question8));
                statistics[0].AverageRating += Double.Parse(s.Question9);
                statistics[0].increment(Int32.Parse(s.Question9));
                statistics[1].AverageRating += Double.Parse(s.Question10);
                statistics[1].increment(Int32.Parse(s.Question10));
                statistics[1].AverageRating += Double.Parse(s.Question11);
                statistics[1].increment(Int32.Parse(s.Question11));
                statistics[1].AverageRating += Double.Parse(s.Question12);
                statistics[1].increment(Int32.Parse(s.Question12));
                statistics[1].AverageRating += Double.Parse(s.Question13);
                statistics[1].increment(Int32.Parse(s.Question13));
                statistics[2].AverageRating += Double.Parse(s.Question14);
                statistics[2].increment(Int32.Parse(s.Question14));
                statistics[2].AverageRating += Double.Parse(s.Question15);
                statistics[2].increment(Int32.Parse(s.Question15));
                statistics[2].AverageRating += Double.Parse(s.Question16);
                statistics[2].increment(Int32.Parse(s.Question16));
                statistics[2].AverageRating += Double.Parse(s.Question17);
                statistics[2].increment(Int32.Parse(s.Question17));
                statistics[2].AverageRating += Double.Parse(s.Question18);
                statistics[2].increment(Int32.Parse(s.Question18));
                statistics[3].AverageRating += Double.Parse(s.Question19);
                statistics[3].increment(Int32.Parse(s.Question19));
                statistics[3].AverageRating += Double.Parse(s.Question20);
                statistics[3].increment(Int32.Parse(s.Question20));
                statistics[4].AverageRating += Double.Parse(s.Question21);
                statistics[4].increment(Int32.Parse(s.Question21));
                statistics[4].AverageRating += Double.Parse(s.Question22);
                statistics[4].increment(Int32.Parse(s.Question22));
                statistics[4].AverageRating += Double.Parse(s.Question23);
                statistics[4].increment(Int32.Parse(s.Question23));
            }

            statistics[0].generatePercents();
            statistics[1].generatePercents();
            statistics[2].generatePercents();
            statistics[3].generatePercents();
            statistics[4].generatePercents();
            statistics[0].AverageRating = statistics[0].AverageRating / reports.Count / 5;
            statistics[1].AverageRating = statistics[1].AverageRating / reports.Count / 4;
            statistics[2].AverageRating = statistics[2].AverageRating / reports.Count / 5;
            statistics[3].AverageRating = statistics[3].AverageRating / reports.Count / 2;
            statistics[4].AverageRating = statistics[4].AverageRating / reports.Count / 3;

            return Round2Decimals(statistics);
        }
    }
}
