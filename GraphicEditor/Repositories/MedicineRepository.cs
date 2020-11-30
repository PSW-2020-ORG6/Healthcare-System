using GraphicEditor.Repositories.Interfaces;
using health_clinic_class_diagram.Backend.Model.Hospital;
using Model.Hospital;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {

        private MySqlConnection connection;
        public MedicineRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<MedicineGEA> GetMedicines(String query)
        {
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<MedicineGEA> resultList = new List<MedicineGEA>();
            while (sqlReader.Read())
            {
                MedicineGEA entity = new MedicineGEA();
                entity.SerialNumber = (string)sqlReader[0];
                entity.CopyrightName = (string)sqlReader[1];
                entity.GenericName = (string)sqlReader[2];
                entity.MedicineManufacturerId = (string)sqlReader[3];
                entity.MedicineTypeId = (string)sqlReader[4];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<MedicineGEA> GetMedicinesByName(string name)
        {
            try
            {
                return GetMedicines("Select * from medicinegea where GenericName like '%" + name + "%'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<MedicineGEA> GetAllMedicines()
        {
            try
            {
                return GetMedicines("Select * from medicinegea");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
