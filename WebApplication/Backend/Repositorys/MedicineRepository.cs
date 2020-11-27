using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class MedicineRepository
    {
        private MySqlConnection connection;
        public MedicineRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        private List<Medicine> GetMedicine(String query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Medicine> resultList = new List<Medicine>();
            while (sqlReader.Read())
            {
                Medicine entity = new Medicine();
                entity.SerialNumber = (string)sqlReader[0];
                entity.CopyrightName = (string)sqlReader[1];
                entity.GenericName = (string)sqlReader[2];
                entity.MedicineManufacturer.Name = (string)sqlReader[3];
                entity.MedicineType.Type = (string)sqlReader[4];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Medicine> GetAllMedicine()
        {
            try
            {
                return GetMedicine("Select * from medicine");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
