// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Util;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class TimeIntervalRepository : ITimeIntervalRepository
//     {
//         private MySqlConnection connection;
//
//         public TimeIntervalRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<TimeInterval> GetTimeIntervals(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<TimeInterval> resultList = new List<TimeInterval>();
//             while (sqlReader.Read())
//             {
//                 TimeInterval entity = new TimeInterval();
//                 entity.Start = (DateTime)sqlReader[1];
//                 entity.End = (DateTime)sqlReader[2];
//                 entity.Id = (string)sqlReader[0];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<TimeInterval> GetAllTimeIntervals()
//         {
//             try
//             {
//                 return GetTimeIntervals("Select * from timeInterval");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public TimeInterval GetTimeIntervalByStart(string start)
//         {
//             try
//             {
//                 return GetTimeIntervals("Select * from timeInterval where Start='" + start + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public TimeInterval GetTimeIntervalByEnd(string end)
//         {
//             try
//             {
//                 return GetTimeIntervals("Select * from timeInterval where End='" + end + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<TimeInterval> GetTimeIntervalsById(string id)
//         {
//             try
//             {
//                 return GetTimeIntervals("Select * from timeInterval where Id='" + id + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public TimeInterval GetTimeIntervalById(string id)
//         {
//             try
//             {
//                 return GetTimeIntervals("Select * from timeinterval where Id='" + id + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
