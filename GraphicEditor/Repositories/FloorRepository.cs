using GraphicEditor.Repositories.Interfaces;
using health_clinic_class_diagram.Backend.Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class FloorRepository : IFloorRepository
    {
        private MySqlConnection connection;
        public FloorRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Floor> GetFloors(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Floor> resultList = new List<Floor>();
            while (sqlReader.Read())
            {
                Floor entity = new Floor();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                entity.BuildingSerialNumber = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Floor> GetAllFloors()
        {
            try
            {
                return GetFloors("Select * from floors");
            }
            catch (Exception)
            {
                return null;
            }
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
