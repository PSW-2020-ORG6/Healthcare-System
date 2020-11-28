using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.AspNetCore.Mvc;
using Model.MedicalExam;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Backend.Util;

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
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }


        public bool AddNewSurvey(Survey surveyText)
        {
            string sqlDml = "INSERT into surveys" +
                "(Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11," +
                "Question12,Question13,Question14,Question15,Question16,Question17,Question18,Question19,Question20,Question21,Question22,Question23,ID,DoctorName)VALUES ('"
                + surveyText.Question1 + "','" + surveyText.Question2 + "','" + surveyText.Question3 + "','" + surveyText.Question4 + "','" + surveyText.Question5
                + "','" + surveyText.Question6 + "','" + surveyText.Question7 + "','" + surveyText.Question8 + "','" + surveyText.Question9 + "','" + surveyText.Question10 +
                "','" + surveyText.Question11 + "','" + surveyText.Question12 + "','" + surveyText.Question13 + "','" + surveyText.Question14 + "','" + surveyText.Question15 +
                "','" + surveyText.Question16 + "','" + surveyText.Question17 + "','" + surveyText.Question18 + "','" + surveyText.Question19 + "','" + surveyText.Question20
                + "','" + surveyText.Question21 + "','" + surveyText.Question22 + "','" + surveyText.question23 + "','" + surveyText.SerialNumber + "','" + surveyText.DoctorName + "')";

            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        internal List<Report> GetReports(string sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Report> resultList = new List<Report>();
            while (sqlReader.Read())
            {
                Report entity = new Report();
                entity.PatientId = (string)sqlReader[3];
                entity.PatientName = (String)sqlReader[1];
                entity.PhysitianName = (String)sqlReader[2];

                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        internal List<string> GetAllDoctorsFromReporstByPatientId(string idPatient)
        {
            List<Report> reports = new List<Report>();
            reports = GetReports("Select * from reports where patientId=" + idPatient.ToString());
            List<String> doctors = new List<String>();
            foreach (Report r in reports)
            {
                doctors.Add(r.PhysitianName);
            }

            return doctors;
        }


        internal List<Survey> GetSurveys(string sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Survey> resultList = new List<Survey>();
            while (sqlReader.Read())
            {
                Survey entity = new Survey();
                entity.question1 = (string)sqlReader[2];
                entity.question2 = (string)sqlReader[3];
                entity.question3 = (string)sqlReader[4];
                entity.question4 = (string)sqlReader[5];
                entity.question5 = (string)sqlReader[6];
                entity.question6 = (string)sqlReader[7];
                entity.question7 = (string)sqlReader[8];
                entity.question8 = (string)sqlReader[9];
                entity.question9 = (string)sqlReader[10];
                entity.question10 = (string)sqlReader[11];
                entity.question11 = (string)sqlReader[12];
                entity.question12 = (string)sqlReader[13];
                entity.question13 = (string)sqlReader[14];
                entity.question14 = (string)sqlReader[15];
                entity.question15 = (string)sqlReader[16];
                entity.question16 = (string)sqlReader[17];
                entity.question17 = (string)sqlReader[18];
                entity.question18 = (string)sqlReader[19];
                entity.question19 = (string)sqlReader[20];
                entity.question20 = (string)sqlReader[21];
                entity.question21 = (string)sqlReader[22];
                entity.question22 = (string)sqlReader[23];
                entity.question23 = (string)sqlReader[24];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }



        public List<StatisticAuxilaryClass> getStatisticsForDoctor(string doctorId)
        {

            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from surveys where DoctorName = '" + doctorId + "' ");

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
                

                statistics[4].AverageRating +=( Double.Parse(s.Question4) + Double.Parse(s.Question3) + Double.Parse(s.Question2) + Double.Parse(s.Question1));
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

       

        public List<StatisticAuxilaryClass> getStatisticsEachQuestion()
        {

            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from surveys");

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

        public List<StatisticAuxilaryClass> getStatisticsEachTopic()
        {

            List<Survey> reports = new List<Survey>();
            reports = GetSurveys("Select * from surveys");

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



            for (int i = 0; i < 5; i++)
            {
                statistics[i].generatePercents();

                if (i == 0)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count/5;
                else if (i == 1)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count/4;
                else if (i == 2)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count/5;
                else if (i == 3)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count/2;
                else if (i == 4)
                    statistics[i].AverageRating = statistics[i].AverageRating / reports.Count/3;
            }
            return round2Decimals(statistics);
        }

        public List<StatisticAuxilaryClass> round2Decimals(List<StatisticAuxilaryClass> input) {
            foreach(StatisticAuxilaryClass i in input) {
               i.AverageRating = Math.Round(i.AverageRating, 2);
            }
            return input;
        }

        public List<double> getStatisticByTopic(int topicID){
            return null;

        }

    }
}
