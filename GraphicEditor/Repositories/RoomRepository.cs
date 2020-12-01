using GraphicEditor.Repositories.Interfaces;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
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
        }

        private List<Room> GetRooms(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Room> resultList = new List<Room>();
            while (sqlReader.Read())
            {
                Room entity = new Room();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.Id = (int)sqlReader[2];
                entity.BuildingSerialNumber = (string)sqlReader[3];
                entity.FloorSerialNumber = (string)sqlReader[4];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Room> GetAllRooms()
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

        public List<Room> GetRoomsByName(string name)
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

        public List<Room> GetRoomsBySerialNumber(string serialNumber)
        {
            try
            {
                return GetRooms("Select * from rooms where SerialNumber like '%" + serialNumber + "%'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
