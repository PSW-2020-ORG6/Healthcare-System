// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Schedule;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class ProcedureTypeRepository : IProcedureTypeRepository
//     {
//         private MySqlConnection connection;
//         private SpecializationRepository specializationRepository = new SpecializationRepository();
//         private EquipmentRepository equipmentRepository = new EquipmentRepository();
//         //private ProcedureTypeEquipmentUsageRepository procedureTypeEquipmentUsageRepository = new ProcedureTypeEquipmentUsageRepository();
//
//         public ProcedureTypeRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<ProcedureType> GetProcedureTypes(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<ProcedureType> resultList = new List<ProcedureType>();
//             while (sqlReader.Read())
//             {
//                 ProcedureType entity = new ProcedureType();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Specialization = specializationRepository.GetSpecializationBySerialNumber((string)sqlReader[3]);
//                 entity.Name = (string)sqlReader[1];
//                 //entity.EstimatedTimeInMinutes = (int)sqlReader[2];
//                 //AddingRequiredEquipments(sqlReader, entity);
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public ProcedureType GetProcedureTypeBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetProcedureTypes("Select * from procedureType where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//         /*
//         private void AddingRequiredEquipments(MySqlDataReader sqlReader, ProcedureType entity)
//         {
//             List<ProcedureTypeEquipmentUsage> procedureTypeEquipmentUsages = procedureTypeEquipmentUsageRepository.GetProcedureTypeEquipmentUsagesByProcedureTypeSerialNumber((string)sqlReader[0]);
//             entity.RequiredEquipment = new List<Equipment>();
//             foreach (ProcedureTypeEquipmentUsage procedureTypeEquipmentUsage in procedureTypeEquipmentUsages)
//             {
//                 entity.RequiredEquipment.Add(procedureTypeEquipmentUsage.Equipment);
//             }
//         
//         }*/
//     }
// }
