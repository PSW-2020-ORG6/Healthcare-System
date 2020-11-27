using GraphicEditor.Repositories.Interfaces;
using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private MySqlConnection connection;
        public BuildingRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        public List<Building> GetBuildings(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Building> resultList = new List<Building>();
            while (sqlReader.Read())
            {
                Building entity = new Building();
                entity.Id = (string)sqlReader[0];
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
            return GetBuildings("Select * from buildings");
        }

        public Building GetBuildingById(String sqlDml)
        {
            try
            {
                Building building = GetBuildings(sqlDml)[0];
                return building;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Building GetBuildingByName(String sqlDml)
        {
            try
            {
                Building building = GetBuildings(sqlDml)[1];
                return building;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Building GetBuildingByColor(String sqlDml)
        {
            try
            {
                Building building = GetBuildings(sqlDml)[2];
                return building;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Building GetBuildingByShape(String sqlDml)
        {
            try
            {
                Building building = GetBuildings(sqlDml)[3];
                return building;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
