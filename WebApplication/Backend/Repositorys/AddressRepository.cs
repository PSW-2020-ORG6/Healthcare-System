// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Util;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class AddressRepository : IAddressRepository
//     {
//         private MySqlConnection connection;
//
//         public AddressRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Address> GetAddresses(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Address> resultList = new List<Address>();
//             while (sqlReader.Read())
//             {
//                 Address entity = new Address();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Street = (string)sqlReader[1];
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Address> GetAllAddresses()
//         {
//             try
//             {
//                 return GetAddresses("Select * from address");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public Address GetAddressBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetAddresses("Select * from address where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//
//         public List<Address> GetAddressesByStreet(string street)
//         {
//             try
//             {
//                 return GetAddresses("Select * from address where Street='" + street + "'");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }
