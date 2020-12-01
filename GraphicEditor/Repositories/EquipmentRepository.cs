using GraphicEditor.Repositories.Interfaces;
using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private MySqlConnection connection;
        private BuildingRepository buildingRepository = new BuildingRepository();
        private FloorRepository floorRepository = new FloorRepository();
        private RoomRepository roomRepository = new RoomRepository();

        public EquipmentRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Equipment> GetEquipments(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Equipment> resultList = new List<Equipment>();
            while (sqlReader.Read())
            {
                Equipment entity = new Equipment();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Id = (string)sqlReader[1];
                entity.RoomId = (string)sqlReader[2];
                entity.Name = (string)sqlReader[3];
                entity.Building = buildingRepository.GetBuildingBySerialNumber((string)sqlReader[4]);
                entity.Floor = floorRepository.GetFloorBySerialNumber((string)sqlReader[5]);
                entity.Room = roomRepository.GetRoomBySerialNumber((string)sqlReader[6]);
                entity.BuildingSerialNumber = (string)sqlReader[4];
                entity.FloorSerialNumber = (string)sqlReader[5];
                entity.RoomSerialNumber = (string)sqlReader[6];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Equipment> GetAllEquipments()
        {
            try
            {
                return GetEquipments("Select * from equipments");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Equipment> GetEquipmentsByName(string name)
        {
            try
            {
                return GetEquipments("Select * from equipments where Name like '%" + name + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber)
        {
            try
            {
                return GetEquipments("Select * from equipments where RoomSerialNumber='" + roomSerialNumber + "'");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
