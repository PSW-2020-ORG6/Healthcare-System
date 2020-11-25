using health_clinic_class_diagram.Backend.Dto;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class RoomRepository
    {
        private MySqlConnection connection;
        public RoomRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        internal List<RoomDTO> GetRooms(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<RoomDTO> resultList = new List<RoomDTO>();
            while (sqlReader.Read())
            {
                RoomDTO entity = new RoomDTO();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Id = (string)sqlReader[1];
                entity.FloorId = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<RoomDTO> GetAllRooms()
        {
            return GetRooms("Select * from rooms");
        }
    }
}
