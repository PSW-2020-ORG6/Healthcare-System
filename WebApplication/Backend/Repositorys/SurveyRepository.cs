using health_clinic_class_diagram.Backend.Model.Survey;
using Microsoft.AspNetCore.Mvc;
using Model.MedicalExam;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class SurveyRepository:ISurveyRepository
    {
        private MySqlConnection connection;
        public SurveyRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=bazamaja1;user=root;password=root");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }
        public bool AddNewSurvey(Survey surveyText)
        {
            string sqlDml ="INSERT into surveys" +
                "(Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11," +
                "Question12,Question13,Question14,Question15,Question16,Question17,Question18,Question19,Question20,Question21,Question22,Question23,ID,DoctorName)VALUES ('"
                + surveyText .Question1+ "','"+ surveyText.Question2 + "','" + surveyText.Question3 + "','" + surveyText.Question4 + "','" + surveyText.Question5
                + "','" + surveyText.Question6 + "','" + surveyText.Question7 + "','" + surveyText.Question8 + "','" + surveyText.Question9 + "','" + surveyText.Question10 +
                "','" + surveyText.Question11 + "','" + surveyText.Question12 + "','" + surveyText.Question13 + "','" + surveyText.Question14 + "','" + surveyText.Question15 +
                "','" + surveyText.Question16 + "','" + surveyText.Question17 + "','" + surveyText.Question18 + "','" + surveyText.Question19 + "','" + surveyText.Question20
                + "','" + surveyText.Question21+ "','" + surveyText.Question22 + "','" + surveyText.question23 + "','" + surveyText.SerialNumber + "','" + surveyText.DoctorName+ "')";

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
            reports=GetReports("Select * from reports where patientId="+idPatient.ToString());
            List<String> doctors = new List<String>();
            foreach (Report r in reports)
            {
                doctors.Add(r.PhysitianName);
            }

            return doctors;
        }
    }
}
