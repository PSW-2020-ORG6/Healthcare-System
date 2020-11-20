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
    
    public class SurveyRepository
    {
        private MySqlConnection connection;
        public SurveyRepository()
        {
            try
            {
                connection = new MySqlConnection("server=localhost;port=3306;database=mydb111;user=root;password=root");
                connection.Open();
            }
            catch (Exception e)
            {
            }
        }

     

        internal bool AddNewSurvey(String Results)
        {
            string[] results = Results.Split(",");
            string sqlDml ="INSERT into surveys" +
                "(Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,Question11," +
                "Question12,Question13,Question14,Question15,Question16,Question17,Question18,Question19,Question20,Question21,Question22,Question23,ID,DoctorName)VALUES ('"
                + results[0]+"','"+ results[1] + "','" + results[2] + "','" + results[3] + "','" + results[4]
                + "','" + results[5] + "','" + results[6] + "','" + results[7] + "','" + results[8] + "','" + results[9] +
                "','" + results[10] + "','" + results[11] + "','" + results[12] + "','" + results[13] + "','" + results[14] +
                "','" + results[15] + "','" + results[16] + "','" + results[17] + "','" + results[18] + "','" + results[19]
                + "','" + results[20]+ "','" + results[21]+ "','" + results[22] + "','" + results[23] + "','" + results[24] + "')";

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
                entity.PatientId = (string)sqlReader[5];
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
