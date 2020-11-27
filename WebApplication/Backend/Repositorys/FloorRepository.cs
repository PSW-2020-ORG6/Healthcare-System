using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class FloorRepository : IFloorRepository
    {
        private MySqlConnection connection;
        public FloorRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        public List<Floor> GetFloors(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Floor> resultList = new List<Floor>();
            while (sqlReader.Read())
            {
                Floor entity = new Floor();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.BuildingName = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Floor> GetAllFloors()
        {
            return GetFloors("Select * from floors");
        }

        public List<Floor> GetFloorsByName(string name)
        {
            try
            {
                return GetFloors("Select * from floors where Name like '%" + name + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
