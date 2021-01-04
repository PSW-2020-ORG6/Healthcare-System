// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
// using HealthClinicBackend.Backend.Model.MedicalExam;
// using HealthClinicBackend.Backend.Model.Survey;
// using WebApplication.Backend.Util;
// using HealthClinicBackend.Backend.Model.Schedule;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class SurveyRepository : ISurveyRepository
//     {
//         private MySqlConnection connection;
//         
//
//         public SurveyRepository()
//         {
//             try
//             {
//                 connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//             }
//             catch (Exception e)
//             {
//             }
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///adding new Survey to database
//         ///</summary>
//         ///<returns>
//         ///true if sucessful,else false
//         ///</returns>
//         ///<param name="surveyText"> Survey type object
//         ///</param>
//         public bool AddNewSurvey(Survey surveyText)
//         {
//             connection.Open();
//             String[] surveyDate = surveyText.ReportDate.ToString().Split(" ");
//             String[] surveyDateParts = surveyDate[0].Split(".");
//             String dateSurvey = surveyDateParts[2] + "-" + surveyDateParts[1]+ "-" + (Int32.Parse(surveyDateParts[0]) + 1).ToString();
//             string sqlDml = "INSERT into survey" +
//                             "(Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11," +
//                             "Question12,Question13,Question14,Question15,Question16,Question17,Question18,Question19,Question20,Question21,Question22,Question23,ID,DoctorName,SerialNumber,reportDate)VALUES ('"
//                             + surveyText.Questions[0] + "','" + surveyText.Questions[1] + "','" + surveyText.Questions[2] +
//                             "','" + surveyText.Questions[3] + "','" + surveyText.Questions[4]
//                             + "','" + surveyText.Questions[5] + "','" + surveyText.Questions[6] + "','" +
//                             surveyText.Questions[7] + "','" + surveyText.Questions[8] + "','" + surveyText.Questions[9] +
//                             "','" + surveyText.Questions[10] + "','" + surveyText.Questions[11] + "','" +
//                             surveyText.Questions[12] + "','" + surveyText.Questions[13] + "','" + surveyText.Questions[14] +
//                             "','" + surveyText.Questions[15] + "','" + surveyText.Questions[16] + "','" +
//                             surveyText.Questions[17] + "','" + surveyText.Questions[18] + "','" + surveyText.Questions[19]
//                             + "','" + surveyText.Questions[20] + "','" + surveyText.Questions[21] + "','" +
//                             surveyText.Questions[22] + "','" + surveyText.PatientId + "','" + surveyText.DoctorName + "','" +
//                             surveyText.SerialNumber + "','" + dateSurvey + "')";
//
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             sqlCommand.ExecuteNonQuery();
//             connection.Close();
//
//             return true;
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///getting all Reports with specific value of parameter
//         ///</summary>
//         ///<returns>
//         ///list of Reports type objects
//         ///</returns>
//         ///<param name="sqlDml"> String sql command
//         ///</param>
//         
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///getting doctor by id
//         ///</summary>
//         ///<returns>
//         ///Physitian type of object
//         ///</returns>
//         ///<param name="sqlDml">String sql command
//         ///</param>
//         internal Physician GetDoctorById(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             Physician entity = new Physician();
//             while (sqlReader.Read())
//             {
//                 entity.Name = (string)sqlReader[1];
//                 entity.Surname = (string)sqlReader[2];
//             }
//             connection.Close();
//             return entity;
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///getting Patient by id
//         ///</summary>
//         ///<returns>
//         ///Patient object type
//         ///</returns>
//         ///<param name="idPetient">Strign id parameter
//         ///</param>
//         internal Patient GetPatientById(string idPetient)
//         {
//             Patient patient = new Patient();
//             patient = GetPatient("Select * from patient where SerialNumber like '" + idPetient + "'");
//             return patient;
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///getting Patient from database
//         ///</summary>
//         ///<returns>
//         ///Patient type of object
//         ///</returns>
//         ///<param name="sqlDml"> String sql command
//         ///</param>
//         internal Patient GetPatient(String sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             Patient patientResutl = new Patient();
//             while (sqlReader.Read())
//             {
//                 Patient entity = new Patient();
//                 entity.Id = (string) sqlReader[3];
//                 entity.Name = (string) sqlReader[1];
//                 entity.Surname = (string) sqlReader[2];
//                 entity.ParentName = (string) sqlReader[7];
//                 entity.SerialNumber = sqlReader[0].ToString();
//                 entity.DateOfBirth = Convert.ToDateTime(sqlReader[4]);
//                 entity.Contact = (string) sqlReader[5];
//                 entity.Email = (string) sqlReader[6];
//                 entity.Gender = (string) sqlReader[8];
//                 entity.Guest = true;
//                 //  Convert.ToBoolean(sqlReader[9]);
//                 entity.Password = "password";
//                 patientResutl = entity;
//             }
//             connection.Close();
//             return patientResutl;
//         }
//         public List<Report>GetReports(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Report> resultList = new List<Report>();
//
//             while (sqlReader.Read())
//             {
//                 Report entity = new Report();
//                 entity.Patient = new Patient { Id = (String)sqlReader[2] };
//                 entity.Physician = new Physician { SerialNumber = (String)sqlReader[3] };
//                 entity.Date = Convert.ToDateTime(sqlReader[1]);
//
//                 resultList.Add(entity);
//
//             }
//             connection.Close();
//             foreach (Report report in resultList)
//             {
//                 report.Physician = GetDoctorById("Select * from physician where SerialNumber like'" + report.Physician.SerialNumber + "'");
//             }
//             return resultList;
//         }
//         public List<Survey> GetSurveys(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Survey> resultList = new List<Survey>();
//             while (sqlReader.Read())
//             {
//                 Survey entity = new Survey();
//                 entity.Questions[0] = (string) sqlReader[3];
//                 entity.Questions[1] = (string) sqlReader[4];
//                 entity.Questions[2] = (string) sqlReader[5];
//                 entity.Questions[3] = (string) sqlReader[6];
//                 entity.Questions[4] = (string) sqlReader[7];
//                 entity.Questions[5] = (string) sqlReader[8];
//                 entity.Questions[6] = (string) sqlReader[9];
//                 entity.Questions[7] = (string) sqlReader[10];
//                 entity.Questions[8] = (string) sqlReader[11];
//                 entity.Questions[9] = (string) sqlReader[12];
//                 entity.Questions[10] = (string) sqlReader[13];
//                 entity.Questions[11] = (string) sqlReader[14];
//                 entity.Questions[12] = (string) sqlReader[15];
//                 entity.Questions[13] = (string) sqlReader[16];
//                 entity.Questions[14] = (string) sqlReader[17];
//                 entity.Questions[15] = (string) sqlReader[18];
//                 entity.Questions[16] = (string) sqlReader[19];
//                 entity.Questions[17]= (string) sqlReader[20];
//                 entity.Questions[18] = (string) sqlReader[21];
//                 entity.Questions[19] = (string) sqlReader[22];
//                 entity.Questions[20] = (string) sqlReader[23];
//                 entity.Questions[21]= (string) sqlReader[24];
//                 entity.Questions[22] = (string) sqlReader[25];
//                 entity.ReportDate = Convert.ToDateTime(sqlReader[26]);
//                 resultList.Add(entity);
//             }
//
//             connection.Close();
//             return resultList;
//         }
//
//         ////Aleksa Repovic RA52/2017
//         /// <summary>
//         ///Return all surveys from database with desired doctors ID
//         ///</summary>
//         ///<returns>
//         ///list of survey objects 
//         ///</returns>
//         public List<Survey> GetSurveysbyDoctorId(string doctorId) {
//
//             List<Survey> reports = new List<Survey>();
//             reports = GetSurveys("Select * from survey where DoctorName like '" + doctorId + "' ");
//
//             return reports;
//         }
//      
//         ////Aleksa Repovic RA52/2017
//         /// <summary>
//         ///Return all surveys from database
//         ///</summary>
//         ///<returns>
//         ///list of survey objects 
//         ///</returns>
//         public List<Survey> GetAllSurveys() {
//             return GetSurveys("Select * from survey");
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///returns all doctors from surveys conducted by one patient
//         ///</summary>
//         ///<returns>
//         ///list of names of doctors
//         ///</returns>
//         ///<param name="idPatient"> String patient id
//         ///</param>
//         ///
//         public List<string> GetAllDoctorsFromReporstByPatientIdFromSurvey(string patientId)
//         {
//             List<Survey> result = GetSurveys("Select * from survey where ID like '" + patientId + "'");
//             List<String> resultList = new List<String>();
//             foreach (Survey r in result)
//             {
//                 resultList.Add(r.DoctorName + "-" + r.ReportDate.ToString().Split(" ")[0]);
//             }
//             return resultList;
//         }
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///getting all doctors from one patient's reports 
//         ///</summary>
//         ///<returns>
//         ///list of names of doctors
//         ///</returns>
//         ///<param name="idPatient"> String patient id
//         ///</param>
//         ///
//         public List<String> GetAllDoctorsFromReporstByPatientId(string patientId)
//         {
//             List<Report> reports =GetReports ("Select * from report where PatientId like'" + patientId.ToString() + "'");
//             List<String> resulList = new List<String>();
//             foreach (Report r in reports)
//             {
//                 PhysicianRepository phisitionRepository = new PhysicianRepository();
//                 List<Physician> physitians = phisitionRepository.GetPhysiciansByFullName(r.Physician.Name + " " + r.Physician.Surname);
//                 foreach (Physician p in physitians)
//                 {
//                     r.Physician.Name = p.Name;
//                     r.Physician.Surname = p.Surname;
//                     resulList.Add(r.Physician.Name + " " + r.Physician.Surname + "-" + r.Date.ToString().Split(" ")[0]);
//                 }
//             }
//             return resulList;
//         }
//
//
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///returns all doctors froma database by patientid
//         ///</summary>
//         ///<returns>
//         ///list of names of doctors
//         ///</returns>
//         ///<param name="sqlDml">String sql command
//         ///</param>
//         ///
//         public List<Physician> GetDoctors(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Physician> resultList = new List<Physician>();
//
//             while (sqlReader.Read())
//             {
//                 Physician entity = new Physician();
//                 entity.Name = (string)sqlReader[2];
//                 resultList.Add(entity);
//
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         
//     }
// }