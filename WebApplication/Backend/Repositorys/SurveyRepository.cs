using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Model.Survey;
using WebApplication.Backend.Util;
using HealthClinicBackend.Backend.Model.Schedule;

namespace WebApplication.Backend.Repositorys
{
    public class SurveyRepository : ISurveyRepository
    {
        private MySqlConnection connection;

        public SurveyRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=neynamneynam12");
            }
            catch (Exception e)
            {
            }
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///adding new Survey to database
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<param name="surveyText"> Survey type object
        ///</param>
        public bool AddNewSurvey(Survey surveyText)
        {
            connection.Open();
            String[] surveyDate = surveyText.ReportDate.ToString().Split(" ");
            String[] surveyDateParts = surveyDate[0].Split("/");
            String dateSurvey = surveyDateParts[2] + "-" + surveyDateParts[0] + "-" + (Int32.Parse(surveyDateParts[1]) + 1).ToString() + " 00:00:00";
            string sqlDml = "INSERT into survey" +
                            "(Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11," +
                            "Question12,Question13,Question14,Question15,Question16,Question17,Question18,Question19,Question20,Question21,Question22,Question23,ID,DoctorName,SerialNumber,reportDate)VALUES ('"
                            + surveyText.Question1 + "','" + surveyText.Question2 + "','" + surveyText.Question3 +
                            "','" + surveyText.Question4 + "','" + surveyText.Question5
                            + "','" + surveyText.Question6 + "','" + surveyText.Question7 + "','" +
                            surveyText.Question8 + "','" + surveyText.Question9 + "','" + surveyText.Question10 +
                            "','" + surveyText.Question11 + "','" + surveyText.Question12 + "','" +
                            surveyText.Question13 + "','" + surveyText.Question14 + "','" + surveyText.Question15 +
                            "','" + surveyText.Question16 + "','" + surveyText.Question17 + "','" +
                            surveyText.Question18 + "','" + surveyText.Question19 + "','" + surveyText.Question20
                            + "','" + surveyText.Question21 + "','" + surveyText.Question22 + "','" +
                            surveyText.Question23 + "','" + surveyText.Id + "','" + surveyText.DoctorName + "','" +
                            surveyText.SerialNumber + "','" + dateSurvey + "')";

            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///getting all Reports with specific value of parameter
        ///</summary>
        ///<returns>
        ///list of Reports type objects
        ///</returns>
        ///<param name="sqlDml"> String sql command
        ///</param>
        internal List<Report> GetReports(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Report> resultList = new List<Report>();

            while (sqlReader.Read())
            {
                Report entity = new Report();
                entity.Patient = new Patient { Id = (String)sqlReader[2] };
                entity.Physician = new Physician { SerialNumber = (String)sqlReader[3] };
                entity.Date = Convert.ToDateTime(sqlReader[1]);

                resultList.Add(entity);

            }
            connection.Close();
            foreach (Report report in resultList)
            {
                report.Physician = GetDoctorById("Select * from physitian where SerialNumber like'" + report.Physician.SerialNumber + "'");
            }
            return resultList;
        }
        ////Vucetic Marija RA157/2017
        /// <summary>
        ///getting doctor by id
        ///</summary>
        ///<returns>
        ///Physitian type of object
        ///</returns>
        ///<param name="sqlDml">String sql command
        ///</param>
        internal Physician GetDoctorById(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            Physician entity = new Physician();
            entity.Name = (string) sqlReader[1];
            entity.Surname = (string) sqlReader[2];
            connection.Close();
            return entity;
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///getting Patient by id
        ///</summary>
        ///<returns>
        ///Patient object type
        ///</returns>
        ///<param name="idPetient">Strign id parameter
        ///</param>
        internal Patient GetPatientById(string idPetient)
        {
            Patient patient = new Patient();
            patient = GetPatient("Select * from patient where SerialNumber like '" + idPetient + "'");
            return patient;
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///getting Patient from database
        ///</summary>
        ///<returns>
        ///Patient type of object
        ///</returns>
        ///<param name="sqlDml"> String sql command
        ///</param>
        internal Patient GetPatient(String sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            Patient patientResutl = new Patient();
            while (sqlReader.Read())
            {
                Patient entity = new Patient();
                entity.Id = (string) sqlReader[3];
                entity.Name = (string) sqlReader[1];
                entity.Surname = (string) sqlReader[2];
                entity.ParentName = (string) sqlReader[7];
                entity.SerialNumber = sqlReader[0].ToString();
                entity.DateOfBirth = Convert.ToDateTime(sqlReader[4]);
                entity.Contact = (string) sqlReader[5];
                entity.Email = (string) sqlReader[6];
                entity.Gender = (string) sqlReader[8];
                entity.Guest = true;
                //  Convert.ToBoolean(sqlReader[9]);
                entity.Password = "password";
                patientResutl = entity;
            }

            connection.Close();
            return patientResutl;
        }

       

        internal List<Survey> GetSurveys(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Survey> resultList = new List<Survey>();
            while (sqlReader.Read())
            {
                Survey entity = new Survey();
                entity.Question1 = (string) sqlReader[2];
                entity.Question2 = (string) sqlReader[3];
                entity.Question3 = (string) sqlReader[4];
                entity.Question4 = (string) sqlReader[5];
                entity.Question5 = (string) sqlReader[6];
                entity.Question6 = (string) sqlReader[7];
                entity.Question7 = (string) sqlReader[8];
                entity.Question8 = (string) sqlReader[9];
                entity.Question9 = (string) sqlReader[10];
                entity.Question10 = (string) sqlReader[11];
                entity.Question11 = (string) sqlReader[12];
                entity.Question12 = (string) sqlReader[13];
                entity.Question13 = (string) sqlReader[14];
                entity.Question14 = (string) sqlReader[15];
                entity.Question15 = (string) sqlReader[16];
                entity.Question16 = (string) sqlReader[17];
                entity.Question17 = (string) sqlReader[18];
                entity.Question18 = (string) sqlReader[19];
                entity.Question19 = (string) sqlReader[20];
                entity.Question20 = (string) sqlReader[21];
                entity.Question21 = (string) sqlReader[22];
                entity.Question22 = (string) sqlReader[23];
                entity.Question23 = (string) sqlReader[24];
                entity.ReportDate = Convert.ToDateTime(sqlReader[26]);
                resultList.Add(entity);
            }

            connection.Close();
            return resultList;
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
        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorId)
        {
            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from survey where DoctorName = '" + doctorId + "' ");

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

            return round2Decimals(statistics);
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
            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from survey");

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

            return round2Decimals(statistics);
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
            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from survey");

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
            return round2Decimals(statistics);
        }


        ////Aleksa Repovic RA52/2017
        /// <summary>
        ///Helping class which rounds double values to 2 decimals
        ///</summary>
        ///<returns>
        ///list of objects containing information about statistics with values rounded to 2 decimals
        ///</returns>
        public List<StatisticAuxilaryClass> round2Decimals(List<StatisticAuxilaryClass> input)
        {
            foreach (StatisticAuxilaryClass i in input)
            {
                i.AverageRating = Math.Round(i.AverageRating, 2);
            }

            return input;
        }

        ////Vucetic Marija RA157/2017
        /// <summary>
        ///returns all doctors from surveys conducted by one patient
        ///</summary>
        ///<returns>
        ///list of names of doctors
        ///</returns>
        ///<param name="idPatient"> String patient id
        ///</param>
        ///
        public List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId)
        {
            List<Survey> result = GetSurveys("Select * from survey where ID like '" + patientId + "'");
            List<String> resultList = new List<String>();
            foreach (Survey r in result)
            {
                resultList.Add(r.DoctorName + "-" + r.ReportDate.ToString().Split(" ")[0]);
            }

            return resultList;
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
        ///
        public List<String> GetAllDoctorsFromReporstByPatientId(string patientId)
        {
            List<Report> reports = GetReports("Select * from report where PatientId like'" + patientId.ToString() + "'");
            List<String> resulList = new List<String>();
            foreach (Report r in reports)
            {
                PhysicianRepository phisitionRepository = new PhysicianRepository();
                List<Physician> physitians = phisitionRepository.GetPhysiciansByFullName(r.Physician.FullName);
                foreach (Physician p in physitians)
                {
                    r.Physician.FullName = p.FullName;
                    resulList.Add(r.Physician.FullName + "-" + r.Date.ToString().Split(" ")[0]);
                }
            }
            return resulList;
        }


        ////Vucetic Marija RA157/2017
        /// <summary>
        ///returns all doctors froma database by patientid
        ///</summary>
        ///<returns>
        ///list of names of doctors
        ///</returns>
        ///<param name="sqlDml">String sql command
        ///</param>
        ///
        public List<Physician> GetDoctors(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Physician> resultList = new List<Physician>();

            while (sqlReader.Read())
            {
                Physician entity = new Physician();
                entity.Name = (string)sqlReader[2];
                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }
        ////Vucetic Marija RA157/2017
        /// <summary>
        /// returns all doctors for whom the patient can do a survey
        ///</summary>
        ///<returns>
        ///list of names of doctors
        ///</returns>
        ///<param name="idPatient"> String patient id
        ///</param>
        ///

        public List<String> GetAllDoctorsFromReporstByPatientIdForSurveyList(string patientId)
        {
            List<String> resultListFromSurvey = GetAllDoctorsFromReporstByPatientIdFromSurvey(patientId);
            List<String> resultListFromReports = GetAllDoctorsFromReporstByPatientId(patientId);
            List<String> resultList = new List<String>();
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<Appointment> pastAppointments = appointmentRepository.GetAllAppointmentsByPatientIdPast(patientId);
            List<String> resultListPastAppointments = new List<string>();

            /*
            foreach (Appointment appointment in pastAppointments)
            {
                resultListPastAppointments.Add(appointment.Physician.FullName + "-" + appointment.Date.ToString().Split(" ")[0]);
            }
            */
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
    }
}