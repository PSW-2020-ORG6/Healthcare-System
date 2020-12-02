using GraphicEditor.Repositories.Interfaces;
using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private MySqlConnection connection;

        public PatientRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=newdb;user=root;password=root");
        }

        private List<Patient> GetPatients(String sqlDml)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Patient> resultList = new List<Patient>();
            while (sqlReader.Read())
            {
                Patient entity = new Patient();
                entity.Id = (string)sqlReader[3];
                entity.Name = (string)sqlReader[1];
                entity.Surname = (string)sqlReader[2];
                entity.ParentName = (string)sqlReader[7];
                entity.SerialNumber = sqlReader[0].ToString();
                entity.DateOfBirth = Convert.ToDateTime(sqlReader[4]);
                entity.Contact = (string)sqlReader[5];
                entity.Email = (string)sqlReader[6];
                entity.Gender = (string)sqlReader[8];
                entity.Password = "password";
                entity.AddressSerialNumber = (string)sqlReader[9];
                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }

        public List<Patient> GetAllPatients()
        {
            return GetPatients("Select * from patients");
        }


        public Patient GetPatientBySerialNumber(string serialNumber)
        {
            try
            {
                return GetPatients("Select * from patients where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
