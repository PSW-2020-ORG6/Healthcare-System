using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class RoomRepository : IRoomRepository
    {
        private MySqlConnection connection;
        public RoomRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<RoomGEA> GetRooms(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<RoomGEA> resultList = new List<RoomGEA>();
            while (sqlReader.Read())
            {
                RoomGEA entity = new RoomGEA();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.FloorName = (string)sqlReader[2];
                entity.BuildingName = (string)sqlReader[3];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<RoomGEA> GetAllRooms()
        {
            try
            {
                return GetRooms("Select * from rooms");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<RoomGEA> GetRoomsByName(string name)
        {
            try
            {
                return GetRooms("Select * from rooms where Name like '%" + name + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
