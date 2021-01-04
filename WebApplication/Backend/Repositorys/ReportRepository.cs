// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Accounts;
// using HealthClinicBackend.Backend.Model.MedicalExam;
// using HealthClinicBackend.Backend.Model.Schedule;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class ReportRepository : IReportRepository
//     {
//         private MySqlConnection connection;
//         public ReportRepository()
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
//         ///Tanja Drcelic RA124/2017 and Marija Vucetic RA157/2017
//         /// <summary>
//         ///Get reports from table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///list of reports
//         ///</returns>
//         private List<Report> GetReports(String sqlDml)
//         {
//             connection.Close();
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Report> resultList = new List<Report>();
//             while (sqlReader.Read())
//             {
//                 Report entity = new Report();
//                 entity.Findings = (string)sqlReader[2];
//                 entity.PatientConditions = (string)sqlReader[5];
//                 entity.Patient = new Patient { SerialNumber = (string)sqlReader[3] };
//                 entity.Physician = new Physician { SerialNumber = (string)sqlReader[4] };
//                 entity.ProcedureType = new ProcedureType { SerialNumber = (string)sqlReader[6] };
//                 entity.Date = (DateTime)sqlReader[1];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             foreach (Report report in resultList)
//             {
//                 PatientRepository patientRepository = new PatientRepository();
//                 report.Patient = patientRepository.GetPatientById(report.Patient.SerialNumber);
//                 PhysicianRepository phisitionRepository = new PhysicianRepository();
//                 report.Physician = phisitionRepository.GetPhysicianById(report.Physician.SerialNumber);
//                 report.ProcedureType = GetProcedureTypeById("Select * from proceduretype where SerialNumber like '" + report.ProcedureType.SerialNumber + "'");
//             }
//             return resultList;
//         }
//
//         ///Tanja Drcelic RA124/2017
//         /// <summary>
//         ///Get procedure type by id from table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///Procedure type
//         ///</returns>
//         private ProcedureType GetProcedureTypeById(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             sqlReader.Read();
//             ProcedureType entity = new ProcedureType();
//             entity.SerialNumber = (string)sqlReader[0];
//             entity.Name = (string)sqlReader[1];
//             entity.Specialization = new Specialization();
//             entity.Specialization = new Specialization { SerialNumber = (string)sqlReader[3] };
//             connection.Close();
//             entity.Specialization = GetSpecialization("Select * from specialization where SerialNumber like '" + entity.Specialization.SerialNumber + "'");
//             return entity;
//         }
//         ///Tanja Drcelic RA124/2017
//         /// <summary>
//         ///Get specialization by id from table
//         ///</summary>
//         ///<param name="sqlDml"> data manipulation language
//         ///</param>
//         ///<returns>
//         ///Physitian
//         ///</returns>
//         private Specialization GetSpecialization(string sqlDml)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             sqlReader.Read();
//             Specialization specialization = new Specialization();
//             specialization.SerialNumber = (string)sqlReader[0];
//             specialization.Name = (string)sqlReader[1];
//             connection.Close();
//             return specialization;
//         }
//
//         ///Tanja Drcelic RA124/2017
//         /// <summary>
//         ///Create sqlDml for get reports
//         ///</summary>
//         ///<param name="property"> search by property
//         ///<param name="value"> search value
//         ///<param name="dateTimes"> search by date times
//         ///<param name="not"> search for negation
//         ///</param>
//         ///<returns>
//         ///list of reports
//         ///</returns>
//         public List<Report> GetReportsByProperty(SearchProperty property, string value, string dateTimes, bool not)
//         {
//             List<Report> reports = GetReports("Select * from report  where Date between " + dateTimes);
//             if (!not && property.Equals(SearchProperty.All))
//                 return GetReportssByAllProperties(value, reports);
//             else if (not && property.Equals(SearchProperty.All))
//                 return GetRepportsByAllPropertiesNegation(value, reports);
//             else if (!not && property.Equals(SearchProperty.Patient))
//                 return GetPrescriptionsByPatient(value, reports);
//             else if (not && property.Equals(SearchProperty.Patient))
//                 return GetPrescriptionsByPatientNegation(value, reports);
//             else if (!not && property.Equals(SearchProperty.Doctor))
//                 return GetPrescriptionsByPhysition(value, reports);
//             else if (not && property.Equals(SearchProperty.Doctor))
//                 return GetPrescriptionsByPhysitionNegation(value, reports);
//             else if (!not && property.Equals(SearchProperty.Specialist))
//                 return GetPrescriptionsBySpecialization(value, reports);
//             else if (not && property.Equals(SearchProperty.Specialist))
//                 return GetPrescriptionsBySpecializationNegation(value, reports);
//             else if (!not && property.Equals(SearchProperty.ProcedureType))
//                 return GetPrescriptionsByProedureType(value, reports);
//             else
//                 return GetPrescriptionsByProedureTypeNegation(value, reports);
//         }
//
//         private List<Report> GetPrescriptionsBySpecializationNegation(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (!report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsByProedureTypeNegation(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (!report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//         private List<Report> GetPrescriptionsByProedureType(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsBySpecialization(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsByPhysitionNegation(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (!report.Physician.Name.ToUpper().Contains(value.ToUpper()) && !report.Physician.Surname.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsByPhysition(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (report.Physician.Name.ToUpper().Contains(value.ToUpper()) || report.Physician.Surname.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsByPatientNegation(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (!report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetPrescriptionsByPatient(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Surname.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//         private List<Report> GetReportssByAllProperties(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (report.Physician.Name.ToUpper().Contains(value.ToUpper()) || report.Physician.Surname.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.Patient.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) || report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//
//         private List<Report> GetRepportsByAllPropertiesNegation(string value, List<Report> reports)
//         {
//             List<Report> resultList = new List<Report>();
//             foreach (Report report in reports)
//             {
//                 if (!report.Physician.Name.ToUpper().Contains(value.ToUpper()) && !report.Physician.Surname.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.Patient.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Name.ToUpper().Contains(value.ToUpper()) && !report.ProcedureType.Specialization.Name.ToUpper().Contains(value.ToUpper()))
//                     resultList.Add(report);
//             }
//             return resultList;
//         }
//     }
// }
