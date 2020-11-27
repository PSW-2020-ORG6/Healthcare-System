﻿using health_clinic_class_diagram.Backend.Model.Hospital;
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
            return GetBuildings("Select * from buildings");
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
