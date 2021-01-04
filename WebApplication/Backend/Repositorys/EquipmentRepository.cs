// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class EquipmentRepository : IEquipmentRepository
//     {
//         private MySqlConnection connection;
//
//         public EquipmentRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Equipment> GetEquipments(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Equipment> resultList = new List<Equipment>();
//             while (sqlReader.Read())
//             {
//                 Equipment entity = new Equipment();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Id = (string)sqlReader[1];
//                 entity.RoomId = (string)sqlReader[2];
//                 entity.Name = (string)sqlReader[3];
//                 entity.BuildingSerialNumber = (string)sqlReader[4];
//                 entity.FloorSerialNumber = (string)sqlReader[5];
//                 entity.RoomSerialNumber = (string)sqlReader[6];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Equipment> GetAllEquipments()
//         {
//             try
//             {
//                 return GetEquipments("Select * from equipment");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public Equipment GetEquipmentsBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetEquipments("Select * from equipment where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Equipment> GetEquipmentsByName(string name)
//         {
//             try
//             {
//                 return GetEquipments("Select * from equipment where Name like '%" + name + "%'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber)
//         {
//             try
//             {
//                 return GetEquipments("Select * from equipment where RoomSerialNumber='" + roomSerialNumber + "'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//     }
// }
