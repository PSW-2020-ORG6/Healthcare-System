using Model.Blog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
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
        ///Tanja Drcelic RA124/2017
        /// <summary>
        ///Get all feedbacks from feedbacks table
        ///</summary>
        ///<returns>
        ///true if sucessful,else false
        ///</returns>
        ///<exception>
        ///if any exception occurs method will return null
        ///</exception>
        internal List<Feedback> GetAllFeedbacks()
        {
                string sql1 = "Select * from feedbacks";
                MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                List<Feedback> resultList = new List<Feedback>();
                while (rdr.Read())
                {
                    Feedback entity = new Feedback();
                    entity.SerialNumber = (string)rdr[4];
                    entity.PatientId = (String)rdr[3];
                    entity.Text = (String)rdr[0];
                    entity.Date = Convert.ToDateTime(rdr[2]);
                    entity.Approved = (Boolean)rdr[1];
                    resultList.Add(entity);

                }
                connection.Close();
                return resultList;
        }

        internal List<Feedback> GetFeedbacks(Boolean approvedF)
        {
                string sql1;
                if(approvedF)
                    sql1 = "Select * from feedbacks where approved is true";
                else
                    sql1 = "Select * from feedbacks where approved is false";

                MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
                MySqlDataReader rdr = cmd1.ExecuteReader();
                List<Feedback> resultList = new List<Feedback>();
                while (rdr.Read())
                {
                    Feedback entity = new Feedback();
                    entity.SerialNumber = (string)rdr[4];
                    entity.PatientId = (String)rdr[3];
                    entity.Text = (String)rdr[0];
                    entity.Date = Convert.ToDateTime(rdr[2]);
                    entity.Approved = (Boolean)rdr[1];
                    resultList.Add(entity);

                }
                connection.Close();
                return resultList;

        }

        internal Feedback GetFeedbackById(string feedbackId)
        {
            throw new NotImplementedException();
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
        internal void SetFeedbackApprovedValue(Feedback feedback)
        {
                string[] dateString = feedback.Date.ToString().Split(" ");
                string[] partsOfDate = dateString[0].Split("/");
                if (feedback.Approved)
                {

                    string sql1 = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 0
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
                    cmd1.ExecuteNonQuery();
             
            }
                else
                {
                    string sql1 = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 1
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";

                    MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
                    cmd1.ExecuteNonQuery();
              
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
                string sqlQueryAdd = "INSERT INTO feedbacks (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + "T" + dateString[1]
                       + "','" +feedback.PatientId + " ','" + feedback.SerialNumber + "')";

                MySqlCommand sqlCommand = new MySqlCommand(sqlQueryAdd, connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();

                return true;
        }

    }
}
