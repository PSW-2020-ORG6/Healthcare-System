// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class PhysicianRepository : IPhysicianRepository
//     {
//         private MySqlConnection connection;
//         private AddressRepository addressRepository = new AddressRepository();
//         private SpecializationRepository specializationRepository = new SpecializationRepository();
//         private TimeIntervalRepository timeIntervalRepository = new TimeIntervalRepository();
//
//         public PhysicianRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Physician> GetPhysicians(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Physician> resultList = new List<Physician>();
//             while (sqlReader.Read())
//             {
//                 Physician entity = new Physician();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Name = (string)sqlReader[1];
//                 entity.Surname = (string)sqlReader[2];
//                 entity.Id = (string)sqlReader[3];
//                 entity.DateOfBirth = (DateTime)sqlReader[4];
//                 entity.Contact = (string)sqlReader[5];
//                 entity.Email = (string)sqlReader[6];
//                 entity.Address = addressRepository.GetAddressBySerialNumber((string)sqlReader[8]);
//                 entity.Password = (string)sqlReader[7];
//                 entity.Specialization = specializationRepository.GetSpecializationsByPhysicianSerialNumber((string)sqlReader[0]);
//                 entity.AddressSerialNumber = (string)sqlReader[8];
//                 entity.WorkSchedule = timeIntervalRepository.GetTimeIntervalById((string)sqlReader[9]);
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Physician> GetAllPhysicians()
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Physician> GetPhysiciansByName(string name)
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician where Name like '%" + name + "%'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Physician> GetPhysiciansByFullName(string fullName)
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician where FullName like '" + fullName + "'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public Physician GetPhysicianBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician where SerialNumber like '" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public Physician GetPhysicianById(string id)
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician where Id='" + id + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Physician> GetPhysicianBySpecialization(string specializationName, string physicianId)
//         {
//             try
//             {
//                 return GetPhysicians("Select * from physician,specialization where specialization.Name='" + specializationName + "' and specialization.PhysicianSerialNumber = physician.SerialNumber and specialization.PhysicianSerialNumber !='" + physicianId + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
