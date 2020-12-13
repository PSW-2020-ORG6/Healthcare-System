using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ProcedureTypeDatabaseSql : GenericDatabaseSql<ProcedureType>, IProcedureTypeRepository
    {
        public override List<ProcedureType> GetAll()
        {
            return dbContext.ProcedureType.ToList();
        }

        public override ProcedureType GetById(string id)
        {
            return dbContext.ProcedureType.Find(id);
        }
    }
}