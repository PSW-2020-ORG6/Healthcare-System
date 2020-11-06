using Model.Blog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class FeedbackRepository
    {

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
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=najnovijaBaza;user=root;password=root");

                string sql1 = "Select * from feedbacks";
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
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
                conn.Close();
                return resultList;
            }catch(Exception e)
            {
                return null;
            }
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
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=najnovijaBaza;user=root;password=root");
                string[] dateString = feedback.Date.ToString().Split(" ");
                string[] partsOfDate = dateString[0].Split(".");
                if (feedback.Approved)
                {

                    string sql1 = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 0
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    string sql1 = "REPLACE  into feedbacks(Text,Approved,Date,PatientId,SerialNumber)Values('" + feedback.Text + "','" + 1
                        + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + " ','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";

                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception e)
            {
              
            }
        }

        internal string AddNewFeedback(Feedback feedback)

        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;database=novaBaza1;user=root;password=neynamneynam12");


            string[] dateString = DateTime.Now.ToString().Split(" ");
            string[] partsOfDate = dateString[0].Split("/");



            string sqlQueryAdd = "INSERT INTO feedbacks (text,approved,date,patientid,serialnumber)  VALUES('" + feedback.Text + "','" + 0 + "','" + partsOfDate[2] + "-" + partsOfDate[1] + "-" + partsOfDate[0] + "T" + dateString[1]
                   + "','" + feedback.PatientId + " ','" + feedback.SerialNumber + "')";

            MySqlCommand sqlCommand = new MySqlCommand(sqlQueryAdd, connection);

            connection.Open();
            sqlCommand.ExecuteNonQuery();

            connection.Close();

            return "200OK";
        }
    }
}
