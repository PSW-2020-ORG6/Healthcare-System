using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class MedicineManufacturerRepository
    {
        private MySqlConnection connection;
        public MedicineManufacturerRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
            connection.Open();
        }

        internal List<MedicineManufacturer> GetMedicineManufacturers(String sqlDml)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sqlDml, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<MedicineManufacturer> resultList = new List<MedicineManufacturer>();
            while (sqlReader.Read())
            {
                MedicineManufacturer entity = new MedicineManufacturer();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<MedicineManufacturer> GetAllMedicineManufacturers()
        {
            return GetMedicineManufacturers("Select * from medicineManufacturers");
        }
    }
}
