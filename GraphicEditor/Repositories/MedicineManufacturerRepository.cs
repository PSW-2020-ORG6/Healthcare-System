using GraphicEditor.Repositories.Interfaces;
using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class MedicineManufacturerRepository : IMedicineManufacturerRepository
    {
        private MySqlConnection connection;
        public MedicineManufacturerRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<MedicineManufacturer> GetMedicineManufacturers(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
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
            try
            {
                return GetMedicineManufacturers("Select * from medicineManufacturers");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MedicineManufacturer GetMedicineManufacturerBySerialNumber(string serialNumber)
        {
            try
            {
                return GetMedicineManufacturers("Select * from medicineManufacturers where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
