using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ProcedureTypeDatabaseSql : GenericDatabaseSql<ProcedureType>, IProcedureTypeRepository
    {
        private EquipmentDatabaseSql equipmentDatabaseSql = new EquipmentDatabaseSql();
        private SpecializationDatabaseSql specializationDatabaseSql = new SpecializationDatabaseSql();
        public override List<ProcedureType> GetAll()
        {
            List<ProcedureType> procedureTypes = dbContext.ProcedureType.ToList();

            List<ProcedureEquipment> procedureEquipment = dbContext.ProcedureEquipment
                .ToList();

            foreach (var procedureType in procedureTypes)
            {
                var equipmentSerialNumber = procedureEquipment
                    .Where(pe => pe.ProcedureTypeSerialNumber.Equals(procedureType.SerialNumber))
                    .Select(procedureEquipment => procedureEquipment.EquipmentSerialNumber)
                    .ToList();

                var equipment = new List<Equipment>();
                foreach (string sn in equipmentSerialNumber)
                {
                    equipment.Add(equipmentDatabaseSql.GetById(sn));
                }
                procedureType.RequiredEquipment = equipment;

                procedureType.Specialization = specializationDatabaseSql.GetById(procedureType.SpecializationSerialNumber);
            }

            return procedureTypes;
        }

        public override ProcedureType GetById(string id)
        {
            return dbContext.ProcedureType.Find(id);
        }
    }
}