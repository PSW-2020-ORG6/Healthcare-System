using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class RoomRepository : IRoomRepository
    {
        private MySqlConnection connection;
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        private RoomTypeRepository roomTypeRepository = new RoomTypeRepository();

        public RoomRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Room> GetRooms(String query)
        {
            connection.Close();
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
                entity.FloorSerialNumber = (string)sqlReader[3];
                entity.BuildingSerialNumber = (string)sqlReader[4];
                entity.RoomTypeSerialNumber = (string)sqlReader[5];
                entity.RoomType = roomTypeRepository.GetRoomTypeBySerialNumber((string)sqlReader[5]);
                entity.Equipment = equipmentRepository.GetEquipmentsByRoomSerialNumber((string)sqlReader[0]);
                entity.Row = (int)sqlReader[6];
                entity.Column = (int)sqlReader[7];
                entity.RowSpan = (int)sqlReader[8];
                entity.ColumnSpan = (int)sqlReader[9];
                entity.Style = (string)sqlReader[10];
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

        public Room GetRoomBySerialNumber(string serialNumber)
        {
            try
            {
                return GetRooms("Select * from rooms where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Room> GetRoomsByFloorSerialNumber(string floorSerialNumber)
        {
            try
            {
                return GetRooms("Select * from rooms where FloorSerialNumber='" + floorSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
