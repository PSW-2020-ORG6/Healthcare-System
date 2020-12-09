using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Util;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    /// <summary>
    /// This class does connection with MySQL database patient table
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private MySqlConnection connection;
        public PatientRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=newdb;user=root;password=root;Convert Zero Datetime=true;");
        }
        ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017 and Aleksa Repovic RA52/2017
        /// <summary>
        ///Get patients from patients table
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of patients
        ///</returns>
        private List<Patient> GetPatients(String sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Patient> resultList = new List<Patient>();
            while (sqlReader.Read())
            {
                Patient entity = new Patient();
                entity.Address = new Address();
                entity.Id = (string)sqlReader[0];
                entity.SerialNumber = (string)sqlReader[1];
                entity.Name = (string)sqlReader[2];
                entity.Surname = (string)sqlReader[3];
                entity.DateOfBirth = (DateTime)sqlReader[5];
                entity.Contact = (string)sqlReader[6];
                entity.Email = (string)sqlReader[7];
                entity.Address.SerialNumber = (string)sqlReader[9];
                entity.Password = (string)sqlReader[8];
                entity.ParentName = (string)sqlReader[10];
                entity.PlaceOfBirth = (string)sqlReader[11];
                entity.MunicipalityOfBirth = (string)sqlReader[12];
                entity.StateOfBirth = (string)sqlReader[13];
                entity.PlaceOfResidence = (string)sqlReader[14];
                entity.MunicipalityOfResidence = (string)sqlReader[15];
                entity.StateOfResidence = (string)sqlReader[16];
                entity.Citizenship = (string)sqlReader[17];
                entity.Nationality = (string)sqlReader[18];
                entity.Profession = (string)sqlReader[19];
                entity.EmploymentStatus = (string)sqlReader[20];
                entity.MaritalStatus = (string)sqlReader[21];
                entity.HealthInsuranceNumber = (string)sqlReader[22];
                entity.FamilyDiseases = (string)sqlReader[23];
                entity.PersonalDiseases = (string)sqlReader[24];
                entity.Gender = (string)sqlReader[25];
                entity.Image = null;
                //(string)sqlReader[26];
                entity.Guest = (bool)sqlReader[27];
                entity.EmailConfirmed = (bool)sqlReader[28];
                // entity.ChosenDoctor = (string)sqlReader[29];

                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }

        ///Aleksa Repović
        /// <summary>
        ///Get patient from patients table by ID
        ///</summary>
        ///<returns>
        ///single instance of Patient object
        ///</returns
        public Patient GetPatientById(string id)
        {
            if (id != null)
            {
                Patient patient = GetPatients("Select * from patient where Id like '" + "0002" + "'")[0];
                return patient;
            }
            return null;
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
            return GetPatients("Select * from patient");
        }


        public Patient GetPatientBySerialNumber(string serialNumber)
        {
            try
            {
                return GetPatients("Select * from patient where SerialNumber like '" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        ///Aleksa Repović
        /// <summary>
        ///Get addresses from addresses 
        ///</summary>
        ///<param name="sqlDml"> data manipulation language
        ///</param>
        ///<returns>
        ///list of adresses
        ///</returns
        public List<Address> GetAddresses(string sqlDml)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Address> resultList = new List<Address>();
            while (sqlReader.Read())
            {
                Address entity = new Address();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Street = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        ///Aleksa Repović
        /// <summary>
        ///Get address from addresses with given id
        ///</summary>
        ///<param name="adressId"> string containing id of adress
        ///</param>
        ///<returns>
        ///single adress
        ///</returns
        public Address GetAddress(string adressId)
        {
            return GetAddresses("Select * from address where SerialNumber = '" + adressId + "'")[0];
        }

    }
}
