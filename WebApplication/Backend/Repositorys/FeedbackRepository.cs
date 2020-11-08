﻿using health_clinic_class_diagram.Backend.Dto;
using Model.Blog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database feedback table
    /// </summary>
    public class FeedbackRepository
    {
        private MySqlConnection connection;
        public FeedbackRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }
        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get all feedbacks from feedbacks table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return null
        ///</exception>
        internal List<Feedback> GetFeedbacks(String sqlQuery)
        {
            // sqlQuery = "Select * from feedbacks";
            MySqlCommand cmd1 = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader sqlReader = cmd1.ExecuteReader();
                List<Feedback> resultList = new List<Feedback>();
                while (sqlReader.Read())
                {
                    Feedback entity = new Feedback();
                    entity.SerialNumber = (string)sqlReader[4];
                    entity.PatientId = (String)sqlReader[3];
                    entity.Text = (String)sqlReader[0];
                    entity.Date = Convert.ToDateTime(sqlReader[2]);
                    entity.Approved = (Boolean)sqlReader[1];
                    resultList.Add(entity);
                }
                connection.Close();
                return resultList;
        }
        ////Vucetic Marija RA157/2017
        /// <summary>
        ///set value of atrribute Approved
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return null
        ///</exception>
        ///<param name="feedback"> Feedback type object
        ///</param>
        internal void SetFeedbackApprovedValue(FeedbackDTO feedback)
        {
                string[] dateString = feedback.Date.ToString().Split(" ");
                string[] partsOfDate = dateString[0].Split("/");
                if (feedback.Approved)
                {
                    string inquiry = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 0
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
                    MySqlCommand sqlCommand = new MySqlCommand(inquiry, connection);
                sqlCommand.ExecuteNonQuery();      
            }
                else
                {
                    string inquiry = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 1
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";

                    MySqlCommand sqlCommand = new MySqlCommand(inquiry, connection);
                    sqlCommand.ExecuteNonQuery();             
            }
               connection.Close();
        }
        ////Repovic Aleksa RA52-2017
        /// <summary>
        ///Adds new row into feedbacks table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return false
        ///</exception>
        ///<param name="feedback"> Feedback type object
        ///</param>
        internal bool AddNewFeedback(Feedback feedback)
        {
                string[] dateString = DateTime.Now.ToString().Split(" ");
                string[] partsOfDate = dateString[0].Split("/");
                string sqlQuery = "INSERT INTO feedbacks (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + "T" + dateString[1]
                       + "','" +feedback.PatientId + " ','" + feedback.SerialNumber + "')";

                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();

                return true;
        }
    }
}
