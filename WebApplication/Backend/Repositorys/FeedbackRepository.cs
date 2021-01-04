// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Dto;
// using HealthClinicBackend.Backend.Model.Blog;
//
// namespace WebApplication.Backend.Repositorys
// {
//     /// <summary>
//     /// This class does connection with MySQL database feedback table
//     /// </summary>
//     public class FeedbackRepository
//     {
//         private MySqlConnection connection;
//         public FeedbackRepository()
//         {
//             try
//             {
//                 connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//             }
//             catch (Exception e)
//             {
//             }
//         }
//         ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Get feedbacks from feedbacks table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of feedbacks
//         ///</returns>
//         internal List<Feedback> GetFeedbacks(String sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Feedback> resultList = new List<Feedback>();
//             while (sqlReader.Read())
//             {
//                 Feedback entity = new Feedback();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.PatientId = (String)sqlReader[1];
//                 entity.Text = (String)sqlReader[2];
//                 entity.Date = Convert.ToDateTime(sqlReader[3]);
//                 entity.Approved = (Boolean)sqlReader[4];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//         ///Tanja Drcelic RA124/2017
//         /// <summary>
//         ///Get feedbacks from feedbacks table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of all feedbacks
//         ///</returns>
//         public List<Feedback> GetAllFeedbacks()
//         {
//             return GetFeedbacks("Select * from feedback");
//         }
//         ///Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Get feedbacks from feedbacks table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of approved feedbacks
//         ///</returns>
//         public List<Feedback> GetApprovedFeedbacks()
//         {
//             return GetFeedbacks("Select * from feedback where approved is true");
//         }
//         ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Get feedbacks from feedbacks table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of disapproved feedbacks
//         ///</returns>
//         public List<Feedback> GetDisapprovedFeedbacks()
//         {
//             return GetFeedbacks("Select * from feedback where approved is false");
//         }
//         ////Vucetic Marija RA157/2017
//         /// <summary>
//         ///set value of atrribute Approved
//         ///</summary>
//         ///<returns>
//         ///true if sucessful,else false
//         ///</returns>
//         ///<exception>
//         ///if any exception occurs method will return null
//         ///</exception>
//         ///<param name="feedback"> Feedback type object
//         ///</param>
//         internal void ApproveFeedback(FeedbackDto feedback)
//         {
//             connection.Open();
//             string[] dateString = feedback.Date.ToString().Split(" ");
//             string[] partsOfDate = dateString[0].Split("/");
//             if (feedback.Approved)
//             {
//                 String sqlDml = "REPLACE  into feedback(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 0
//                     + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//             }
//             else
//             {
//                 string sqlDml = "REPLACE  into feedback(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 1
//                     + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
//
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//             }
//             connection.Close();
//         }
//         ////Repovic Aleksa RA52-2017
//         /// <summary>
//         ///Adds new row into feedbacks table
//         ///</summary>
//         ///<returns>
//         ///true if sucessful,else false
//         ///</returns>
//         ///<exception>
//         ///if any exception occurs method will return false
//         ///</exception>
//         ///<param name="feedback"> Feedback type object
//         ///</param>
//         internal bool AddNewFeedback(Feedback feedback)
//         {
//             connection.Open();
//             string[] dateString = DateTime.Now.ToString().Split(" ");
//             string[] partsOfDate = dateString[0].Split("/");
//             string sqlDml = "INSERT INTO feedback (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
//                    + "','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
//
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             sqlCommand.ExecuteNonQuery();
//             connection.Close();
//
//             return true;
//         }
//     }
// }
