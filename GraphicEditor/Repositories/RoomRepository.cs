using GraphicEditor.Repositories.Interfaces;
using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private MySqlConnection connection;
        public RoomRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        public List<RoomGEA> GetRooms(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<RoomGEA> resultList = new List<RoomGEA>();
            while (sqlReader.Read())
            {
                RoomGEA entity = new RoomGEA();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Id = (string)sqlReader[1];
                entity.FloorId = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<RoomGEA> GetAllRooms()
        {
            return GetRooms("Select * from rooms");
        }

        public RoomGEA GetRoomById(String sqlDml)
        {
            try
            {
                RoomGEA room = GetRooms(sqlDml)[1];
                return room;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public RoomGEA GetRoomByName(String sqlDml)
        {
            try
            {
                RoomGEA room = GetRooms(sqlDml)[0];
                return room;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public RoomGEA GetRoomByFloorId(String sqlDml)
        {
            try
            {
                RoomGEA room = GetRooms(sqlDml)[2];
                return room;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
