// using HealthClinicBackend.Backend.Dto;
// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
//
// namespace WebApplication.Backend.Repositorys
// {
//     /// <summary>
//     /// This class does connection with MySQL database patient and address tables
//     /// </summary>
//     public class RegistrationRepository : IRegistrationRepository
//     {
//         private MySqlConnection connection;
//         public RegistrationRepository()
//         {
//             try
//             {
//                 connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//             }
//             catch (Exception e)
//             {
//             }
//         }
//
//         ////Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Adds new row into patient table
//         ///</summary>
//         ///<returns>
//         ///true if sucessful,else false
//         ///</returns>
//         ///<param name="patient"> Patient type object
//         ///</param>
//         public bool AddPatient(Patient patient)
//         {
//             connection.Open();
//             string[] dateString = patient.DateOfBirth.ToString().Split(" ");
//             string[] partsOfDate = dateString[0].Split("/");
//             string sqlDml1 = "INSERT into address (SerialNumber,Street)VALUES('" + patient.Address.SerialNumber + " ','" + patient.Address.Street + "')";
//             MySqlCommand sqlCommand1 = new MySqlCommand(sqlDml1, connection);
//             sqlCommand1.ExecuteNonQuery();
//             if (patient.Guest)
//             {
//                 string sqlDml = "INSERT into patient (Id,SerialNumber,Name,Surname,DateOfBirth,Contact,Email,AddressSerialNumber,Password,ParentName,PlaceOfBirth,MunicipalityOfBirth,StateOfBirth,PlaceOfResidence,MunicipalityOfResidence,StateOfResidence,Citizenship,Nationality,Profession,EmploymentStatus,MaritalStatus,HealthInsuranceNumber,FamilyDiseases,PersonalDiseases,Gender,Image,Guest,EmailConfirmed,ChosenDoctor,IsMalicious,IsBlocked)  VALUES('" + patient.Id + "','" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + patient.Name + " " + patient.Surname + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
//                            + " ','" + patient.Contact + " ','" + patient.Email + " ','" + patient.Address.SerialNumber + " ','" + patient.Password + " ','" + patient.ParentName + " ','" + patient.PlaceOfBirth
//                            + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Citizenship + " ','" + patient.Nationality + " ','" +
//                             patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" +
//                              patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + patient.Gender + " ','" + patient.Image + " ','" + 0 + " ','" + 0 + " ','" + patient.ChosenPhysician + " ','" + 0 + " ','" + 0 + "')";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//             }
//             else
//             {
//                 string sqlDml = "INSERT into patient (Id,SerialNumber,Name,Surname,DateOfBirth,Contact,Email,AddressSerialNumber,Password,ParentName,PlaceOfBirth,MunicipalityOfBirth,StateOfBirth,PlaceOfResidence,MunicipalityOfResidence,StateOfResidence,Citizenship,Nationality,Profession,EmploymentStatus,MaritalStatus,HealthInsuranceNumber,FamilyDiseases,PersonalDiseases,Gender,Image,Guest,EmailConfirmed,ChosenDoctor,IsMalicious,IsBlocked)  VALUES('" + patient.Id + "','" + patient.SerialNumber + "','" + patient.Name + "','" + patient.Surname + "','" + partsOfDate[2] + "-" + partsOfDate[0] + "-" + partsOfDate[1] + "T" + dateString[1]
//                            + " ','" + patient.Contact + " ','" + patient.Email + " ','" + patient.Address.SerialNumber + " ','" + patient.Password + " ','" + patient.ParentName + " ','" + patient.PlaceOfBirth
//                            + "','" + patient.MunicipalityOfBirth + " ','" + patient.StateOfBirth + " ','" + patient.PlaceOfResidence + " ','" + patient.MunicipalityOfResidence + " ','" + patient.StateOfResidence + " ','" + patient.Citizenship + " ','" + patient.Nationality + " ','" +
//                             patient.Profession + " ','" + patient.EmploymentStatus + " ','" + patient.MaritalStatus + " ','" +
//                              patient.HealthInsuranceNumber + " ','" + patient.FamilyDiseases + " ','" + patient.PersonalDiseases + " ','" + patient.Gender + " ','" + patient.Image + " ','" + 1 + " ','" + 0 + " ','" + patient.ChosenPhysician + " ','" + 0 + " ','" + 0 + "')";
//                 MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//                 sqlCommand.ExecuteNonQuery();
//             }
//             connection.Close();
//
//             return true;
//         }
//
//         ///Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Get id from feedbacks table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///id if exists,else false
//         ///</returns>
//         public String GetPatientId(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             string id = "";
//             while (sqlReader.Read())
//             {
//                 id = (string)sqlReader[0];
//             }
//             connection.Close();
//             return id;
//         }
//
//         public bool IsPatientIdValid(string patientId)
//         {
//             string id = GetPatientId("Select id from patient where id=" + patientId);
//             if (id == "" || id == null)
//             {
//                 return true;
//             }
//             return false;
//         }
//
//         ////Aleksandra Milijevic RA 22/2017
//         /// <summary>
//         ///Update row into patient table
//         ///</summary>
//         ///<returns>
//         ///true if sucessful,else false
//         ///</returns>
//         ///<param name="patientId"> String type object
//         ///</param>
//         public bool ConfirmEmailUpdate(string patientId)
//         {
//             connection.Open();
//             string sqlDml = "UPDATE patient SET EmailConfirmed = '1' WHERE (Id = '" + patientId + "')";
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             sqlCommand.ExecuteNonQuery();
//             connection.Close();
//             return true;
//         }
//
//         public List<FamilyDoctorDto> GetAllGeneralPracticePhysicians()
//         {
//             return GetPhysitiansWithSpecializations("Select physician.SerialNumber,physician.Name,physician.Surname, specialization.Name from physician,specialization where specialization.PhysicianSerialNumber= physician.SerialNumber and specialization.Name like 'General practitioner'");
//         }
//
//         private List<FamilyDoctorDto> GetPhysitiansWithSpecializations(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<FamilyDoctorDto> familyDoctors = new List<FamilyDoctorDto>();
//             string id = "";
//             while (sqlReader.Read())
//             {
//                 FamilyDoctorDto entity = new FamilyDoctorDto();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Name = (string)sqlReader[1];
//                 entity.Surname = (string)sqlReader[2];
//                 entity.Specialization = (string)sqlReader[3];
//                 familyDoctors.Add(entity);
//             }
//             connection.Close();
//             return familyDoctors;
//         }
//     }
// }
