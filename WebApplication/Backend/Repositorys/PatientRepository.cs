// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
// using HealthClinicBackend.Backend.Model.Util;
// using WebApplication.Backend.Repositorys.Interfaces;
// using HealthClinicBackend.Backend.Dto;
//
// namespace WebApplication.Backend.Repositorys
// {
//     /// <summary>
//     /// This class does connection with MySQL database patient table
//     /// </summary>
//     public class PatientRepository : IPatientRepository
//     {
//         private MySqlConnection connection;
//         private PhysicianRepository physicianRepository = new PhysicianRepository();
//         private AddressRepository addressRepository = new AddressRepository();
//         public PatientRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//         ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017 and Aleksa Repovic RA52/2017
//         /// <summary>
//         ///Get patients from patients table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of patients
//         ///</returns>
//         private List<Patient> GetPatients(String sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Patient> resultList = new List<Patient>();
//             while (sqlReader.Read())
//             {
//                 Patient entity = new Patient();
//                 entity.Address = new Address();
//                 entity.Id = (string)sqlReader[0];
//                 entity.SerialNumber = (string)sqlReader[1];
//                 entity.Name = (string)sqlReader[2];
//                 entity.Surname = (string)sqlReader[3];
//                 entity.DateOfBirth = (DateTime)sqlReader[4];
//                 entity.Contact = (string)sqlReader[5];
//                 entity.Email = (string)sqlReader[6];
//                 entity.Address = addressRepository.GetAddressBySerialNumber((string)sqlReader[8]);
//                 entity.Password = (string)sqlReader[7];
//                 entity.ParentName = (string)sqlReader[9];
//                 entity.PlaceOfBirth = (string)sqlReader[10];
//                 entity.MunicipalityOfBirth = (string)sqlReader[11];
//                 entity.StateOfBirth = (string)sqlReader[12];
//                 entity.PlaceOfResidence = (string)sqlReader[13];
//                 entity.MunicipalityOfResidence = (string)sqlReader[14];
//                 entity.StateOfResidence = (string)sqlReader[15];
//                 entity.Citizenship = (string)sqlReader[16];
//                 entity.Nationality = (string)sqlReader[17];
//                 entity.Profession = (string)sqlReader[18];
//                 entity.EmploymentStatus = (string)sqlReader[19];
//                 entity.MaritalStatus = (string)sqlReader[20];
//                 entity.HealthInsuranceNumber = (string)sqlReader[21];
//                 entity.FamilyDiseases = (string)sqlReader[22];
//                 entity.PersonalDiseases = (string)sqlReader[23];
//                 entity.Gender = (string)sqlReader[24];
//                 entity.Image = (string)sqlReader[25];
//                 entity.Guest = (bool)sqlReader[26];
//                 entity.EmailConfirmed = (bool)sqlReader[27];
//                 Physician p = physicianRepository.GetPhysicianBySerialNumber((string)sqlReader[28]);
//                 entity.ChosenPhysician = p.Name + " " + p.Surname;
//                 resultList.Add(entity);
//
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         ///Aleksa Repović
//         /// <summary>
//         ///Get patient from patients table by ID
//         ///</summary>
//         ///<returns>
//         ///single instance of Patient object
//         ///</returns
//         public Patient GetPatientById(string id)
//         {
//             if (id != null)
//             {
//                 Patient patient = GetPatients("Select * from patient where Id like '" + "0002" + "'")[0];
//                 return patient;
//             }
//             return null;
//         }
//
//         ///Tanja Drcelic RA124/2017 and Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Get patients from patients table
//         ///</summary>
//         ///<returns>
//         ///list of all patients
//         ///</returns>
//         public List<Patient> GetAllPatients()
//         {
//             return GetPatients("Select * from patient");
//         }
//
//
//         public Patient GetPatientBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetPatients("Select * from patient where SerialNumber like '" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//
//         ///Aleksa Repović
//         /// <summary>
//         ///Get addresses from addresses 
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of adresses
//         ///</returns
//         public List<Address> GetAddresses(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Address> resultList = new List<Address>();
//             while (sqlReader.Read())
//             {
//                 Address entity = new Address();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Street = (string)sqlReader[1];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         ///Aleksa Repović
//         /// <summary>
//         ///Get address from addresses with given id
//         ///</summary>
//         ///<param name="adressId"> string containing id of adress
//         ///</param>
//         ///<returns>
//         ///single adress
//         ///</returns
//         public Address GetAddress(string adressId)
//         {
//             return GetAddresses("Select * from address where SerialNumber = '" + adressId + "'")[0];
//         }
//
//         public List<Patient> GetMaliciousPatients()
//         {
//             return GetPatients("Select * from patient where IsMalicious = '1' and IsBlocked = '0' ");
//         }
//
//         public bool BlockMaliciousPatient(string patientId)
//         {
//             try
//             {
//                 connection.Open();
//                 String sqlDml = "UPDATE patient SET IsBlocked = '1'  WHERE id like '" + patientId + "'";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//
//                 connection.Close();
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 return false;
//             }
//         }
//
//     }
// }
