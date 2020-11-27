using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database patient table
    /// </summary>
    public class PatientRepository
    {
        private MySqlConnection connection;
        public PatientRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();

        }
        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get patients from patients table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of patients
        ///</returns>
        internal List<Patient> GetPatients(String query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Patient> resultList = new List<Patient>();
            while (sqlReader.Read())
            {
                Patient entity = new Patient();
                entity.Id = (string)sqlReader[3];
                entity.Name = (string)sqlReader[1];
                entity.Surname = (string)sqlReader[2];
                entity.ParentName = (string)sqlReader[7];
                entity.SerialNumber = (string)sqlReader[0];
                entity.DateOfBirth = (DateTime)sqlReader[4];
                entity.Contact = (string)sqlReader[5];
                entity.Email = (string)sqlReader[6];
                entity.Gender = (string)sqlReader[8];
                entity.Guest = (Boolean)sqlReader[9];
                entity.Password = (string)sqlReader[10];
                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }
        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
        /// <summary>
        ///Get patients from patients table
        ///</summary>
        ///<returns>
        ///list of all patients
        ///</returns>
        public List<Patient> GetAllPatients()
        {
            return GetPatients("Select * from patients");
        }
    }
}
