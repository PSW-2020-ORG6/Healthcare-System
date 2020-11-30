using GraphicEditor.Repositories.Interfaces;
using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private MySqlConnection connection;
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
                entity.RoomId = (string)sqlReader[1];
                entity.Name = (string)sqlReader[2];
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
    }
}
