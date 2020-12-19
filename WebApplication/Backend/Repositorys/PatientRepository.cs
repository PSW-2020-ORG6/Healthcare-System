// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
// using HealthClinicBackend.Backend.Model.Util;
// using HealthClinicBackend.Backend.Repository.DatabaseSql;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     /// <summary>
//     /// This class does connection with MySQL database patient table
//     /// </summary>
//     public class PatientRepository : IPatientRepository
//     {
//         private readonly PatientDatabaseSql _patientRepository;
//         private readonly AddressDatabaseSql _addressRepository;
//
//         public PatientRepository()
//         {
//             _patientRepository = new PatientDatabaseSql();
//             _addressRepository = new AddressDatabaseSql();
//         }
//
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
//             return _patientRepository.GetAll();
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
//             return _patientRepository.GetByJmbg(id);
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
//             return _patientRepository.GetAll();
//         }
//
//
//         public Patient GetPatientBySerialNumber(string serialNumber)
//         {
//             return _patientRepository.GetById(serialNumber);
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
//             return _addressRepository.GetById(adressId);
//         }
//     }
// }