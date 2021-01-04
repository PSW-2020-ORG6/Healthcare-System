// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class RoomTypeRepository: IRoomTypeRepository
//     {
//         private MySqlConnection connection;
//         public RoomTypeRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<RoomType> GetRoomTypes(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<RoomType> resultList = new List<RoomType>();
//             while (sqlReader.Read())
//             {
//                 RoomType entity = new RoomType();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Name = (string)sqlReader[1];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<RoomType> GetAllGetRoomTypes()
//         {
//             try
//             {
//                 return GetRoomTypes("Select * from roomType");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public RoomType GetRoomTypeBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetRoomTypes("Select * from roomtype where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
