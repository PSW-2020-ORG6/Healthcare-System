using Backend.Repository;
using Model.Blog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class FeedbackRepository
    {
        internal List<Feedback> GetAllFeedbacks()
        {
            throw new NotImplementedException();
        }

        internal Feedback GetFeedbackById(string feedbackId)
        {
            throw new NotImplementedException();
        }
        internal void SetFeedbackApprovedValue(Feedback feedback)
        {
            throw new NotImplementedException();
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
