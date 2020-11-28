using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class FloorRepository
    {
        private MySqlConnection connection;
        public FloorRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        internal List<Floor> GetFloors(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Floor> resultList = new List<Floor>();
            while (sqlReader.Read())
            {
                Floor entity = new Floor();
                entity.Id = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.BuildingId = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Floor> GetAllFloors()
        {
            return GetFloors("Select * from floors");
        }
    }
}
