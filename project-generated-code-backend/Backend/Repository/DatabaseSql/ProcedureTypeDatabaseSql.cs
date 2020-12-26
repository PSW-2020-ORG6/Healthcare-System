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
        public ProcedureTypeDatabaseSql() : base()
        {
        }

        public ProcedureTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<ProcedureType> GetAll()
        {
            List<ProcedureType> procedureTypes = DbContext.ProcedureType.ToList();

            List<ProcedureEquipment> procedureEquipment = DbContext.ProcedureEquipment
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
                    equipment.Add(DbContext.Equipment.Find(sn));
                }
                procedureType.RequiredEquipment = equipment;

                procedureType.Specialization = DbContext.Specialization.Find(procedureType.SpecializationSerialNumber);
            }

            return procedureTypes;
        }

        public override ProcedureType GetById(string id)
        {
            return DbContext.ProcedureType.Find(id);
        }
    }
}