using health_clinic_class_diagram.Backend.Model.Schedule;
using Model.Hospital;
using Model.Schedule;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public class ProcedureTypeRepository
    {
        private MySqlConnection connection;
        private SpecializationRepository specializationRepository = new SpecializationRepository();
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        private ProcedureTypeEquipmentUsageRepository procedureTypeEquipmentUsageRepository = new ProcedureTypeEquipmentUsageRepository();

        public ProcedureTypeRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<ProcedureType> GetProcedureTypes(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<ProcedureType> resultList = new List<ProcedureType>();
            while (sqlReader.Read())
            {
                ProcedureType entity = new ProcedureType();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Specialization = specializationRepository.GetSpecializationBySerialNumber((string)sqlReader[1]);
                entity.Name = (string)sqlReader[2];
                entity.EstimatedTimeInMinutes = (int)sqlReader[3];
                AddingRequiredEquipments(sqlReader, entity);
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public ProcedureType GetProcedureTypeBySerialNumber(string serialNumber)
        {
            try
            {
                return GetProcedureTypes("Select * from procedureTypes where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private void AddingRequiredEquipments(MySqlDataReader sqlReader, ProcedureType entity)
        {
            List<ProcedureTypeEquipmentUsage> procedureTypeEquipmentUsages = procedureTypeEquipmentUsageRepository.GetProcedureTypeEquipmentUsagesByProcedureTypeSerialNumber((string)sqlReader[0]);
            entity.RequiredEquipment = new List<Equipment>();
            foreach (ProcedureTypeEquipmentUsage procedureTypeEquipmentUsage in procedureTypeEquipmentUsages)
            {
                entity.RequiredEquipment.Add(procedureTypeEquipmentUsage.Equipment);
            }
        }
    }
}
