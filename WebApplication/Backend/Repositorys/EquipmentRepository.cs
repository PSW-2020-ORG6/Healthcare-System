using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class EquipmentRepository
    {
        private MySqlConnection connection;
        public EquipmentRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        private List<Equipment> GetEquipments(String query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Equipment> resultList = new List<Equipment>();
            while (sqlReader.Read())
            {
                Equipment entity = new Equipment();
                entity.Name = (string)sqlReader[0];
                entity.Id = (string)sqlReader[1];
                entity.RoomId = (string)sqlReader[2];
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
    }
}
