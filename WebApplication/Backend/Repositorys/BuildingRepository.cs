using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class BuildingRepository : IBuildingRepository
    {
        private MySqlConnection connection;
        public BuildingRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Building> GetBuildings(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Building> resultList = new List<Building>();
            while (sqlReader.Read())
            {
                Building entity = new Building();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.Color = (string)sqlReader[2];
                entity.Shape = (string)sqlReader[3];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Building> GetAllBuildings()
        {
            try
            {
                return GetBuildings("Select * from buildings");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Building> GetBuildingsByName(string name)
        {
            try
            {
                return GetBuildings("Select * from buildings where Name like '%" + name + "%'");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
