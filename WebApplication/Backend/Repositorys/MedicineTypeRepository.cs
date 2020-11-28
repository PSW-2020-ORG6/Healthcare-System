using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class MedicineTypeRepository
    {
        private MySqlConnection connection;
        public MedicineTypeRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        private List<MedicineType> GetMedicineTypes(String query)
        {
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<MedicineType> resultList = new List<MedicineType>();
            while (sqlReader.Read())
            {
                MedicineType entity = new MedicineType();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Type = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<MedicineType> GetAllMedicineTypes()
        {
            try
            {
                return GetMedicineTypes("Select * from medicineTypes");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
