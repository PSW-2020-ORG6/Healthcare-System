using health_clinic_class_diagram.Backend.Model.Schedule;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class ProcedureTypeEquipmentUsageRepository
    {
        private MySqlConnection connection;
        private ProcedureTypeRepository procedureTypeRepository = new ProcedureTypeRepository();
        private EquipmentRepository equipmentRepository = new EquipmentRepository();

        public ProcedureTypeEquipmentUsageRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsages(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<ProcedureTypeEquipmentUsage> resultList = new List<ProcedureTypeEquipmentUsage>();
            while (sqlReader.Read())
            {
                ProcedureTypeEquipmentUsage entity = new ProcedureTypeEquipmentUsage();
                entity.SerialNumber = (string)sqlReader[0];
                entity.ProcedureType = procedureTypeRepository.GetProcedureTypeBySerialNumber((string)sqlReader[1]);
                entity.Equipment = equipmentRepository.GetEquipmentsBySerialNumber((string)sqlReader[2]);
                entity.ProcedureTypeSerialNumber = (string)sqlReader[1];
                entity.EquipmentSerialNumber = (string)sqlReader[2];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<ProcedureTypeEquipmentUsage> GetAllProcedureTypeEquipmentUsages()
        {
            try
            {
                return GetProcedureTypeEquipmentUsages("Select * from procedureTypeEquipmentUsages");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProcedureTypeEquipmentUsage GetProcedureTypeEquipmentUsageBySerialNumber(string serialNumber)
        {
            try
            {
                return GetProcedureTypeEquipmentUsages("Select * from procedureTypeEquipmentUsages where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByEquipmentSerialNumber(string equipmentSerialNumber)
        {
            try
            {
                return GetProcedureTypeEquipmentUsages("Select * from procedureTypeEquipmentUsages where EquipmentSerialNumber='" + equipmentSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<ProcedureTypeEquipmentUsage> GetProcedureTypeEquipmentUsagesByProcedureTypeSerialNumber(string procedureTypeSerialNumber)
        {
            try
            {
                return GetProcedureTypeEquipmentUsages("Select * from procedureTypeEquipmentUsages where ProcedureTypeSerialNumber='" + procedureTypeSerialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
