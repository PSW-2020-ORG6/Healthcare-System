﻿using Model.Hospital;
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

        internal List<Equipment> GetEquipments(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Equipment> resultList = new List<Equipment>();
            while (sqlReader.Read())
            {
                Equipment entity = new Equipment();
                entity.Name = (String)sqlReader[0];
                entity.Id = (String)sqlReader[1];
                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }

        public List<Equipment> GetAllEquipments()
        {
            return GetEquipments("Select * from equipments");
        }
    }
}
