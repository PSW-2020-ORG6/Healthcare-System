// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class MedicineTypeRepository : IMedicineTypeRepository
//     {
//         private MySqlConnection connection;
//         public MedicineTypeRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<MedicineType> GetMedicineTypes(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<MedicineType> resultList = new List<MedicineType>();
//             while (sqlReader.Read())
//             {
//                 MedicineType entity = new MedicineType();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Type = (string)sqlReader[1];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<MedicineType> GetAllMedicineTypes()
//         {
//             try
//             {
//                 return GetMedicineTypes("Select * from medicineType");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public MedicineType GetMedicineTypeBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetMedicineTypes("Select * from medicineType where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
