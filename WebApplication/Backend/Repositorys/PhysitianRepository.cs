﻿using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Repositorys
{
    public class PhysitianRepository
    {
        private MySqlConnection connection;
        public PhysitianRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=Tanjaa;password=TanjaaD");
            connection.Open();

        }
        internal List<Physitian> GetPhysitian(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Physitian> resultList = new List<Physitian>();
            while (sqlReader.Read())
            {
                Physitian entity = new Physitian();
                resultList.Add(entity);

            }
            connection.Close();
            return resultList;
        }

        public Physitian GetPhysitianById(String sqlDml)
        {
            try
            {
                Physitian physitian = GetPhysitian(sqlDml)[0];
                return physitian;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
