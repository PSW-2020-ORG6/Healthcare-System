using GraphicEditor.Repositories.Interfaces;
using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private MySqlConnection connection;
        private MedicineManufacturerRepository medicineManufacturer = new MedicineManufacturerRepository();
        private MedicineTypeRepository medicineType = new MedicineTypeRepository();

        public MedicineRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Medicine> GetMedicines(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Medicine> resultList = new List<Medicine>();
            while (sqlReader.Read())
            {
                Medicine entity = new Medicine();
                entity.SerialNumber = (string)sqlReader[0];
                entity.CopyrightName = (string)sqlReader[1];
                entity.GenericName = (string)sqlReader[2];
                entity.MedicineManufacturer = medicineManufacturer.GetMedicineManufacturerBySerialNumber((string)sqlReader[3]);
                entity.MedicineType = medicineType.GetMedicineTypeBySerialNumber((string)sqlReader[4]);
                entity.MedicineManufacturerSerialNumber = (string)sqlReader[3];
                entity.MedicineTypeSerialNumber = (string)sqlReader[4];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Medicine> GetMedicinesByName(string name)
        {
            try
            {
                return GetMedicines("Select * from medicine where GenericName like '%" + name + "%'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Medicine> GetAllMedicines()
        {
            try
            {
                return GetMedicines("Select * from medicine");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
