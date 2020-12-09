using System.Collections.Generic;
using System.Linq;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ProcedureTypeDatabaseSql: GenericDatabaseSql<ProcedureType>, IProcedureTypeRepository
    {
        public override List<ProcedureType> GetAll()
        {
            return dbContext.ProcedureType.ToList();
        }
    }
}