// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class FloorRepository : IFloorRepository
//     {
//         private MySqlConnection connection;
//         private RoomRepository roomRepository = new RoomRepository();
//
//         public FloorRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Floor> GetFloors(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Floor> resultList = new List<Floor>();
//             while (sqlReader.Read())
//             {
//                 Floor entity = new Floor();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Name = (string)sqlReader[1];
//                 entity.BuildingSerialNumber = (string)sqlReader[2];
//                 entity.Rooms = roomRepository.GetRoomsByFloorSerialNumber((string)sqlReader[0]);
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Floor> GetAllFloors()
//         {
//             try
//             {
//                 return GetFloors("Select * from floor");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Floor> GetFloorsByName(string name)
//         {
//             try
//             {
//                 return GetFloors("Select * from floor where Name like '%" + name + "%'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Floor> GetFloorsByBuildingSerialNumber(string buildingSerialNumber)
//         {
//             try
//             {
//                 return GetFloors("Select * from floor where BuildingSerialNumber='" + buildingSerialNumber + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public Floor GetFloorBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetFloors("Select * from floor where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
