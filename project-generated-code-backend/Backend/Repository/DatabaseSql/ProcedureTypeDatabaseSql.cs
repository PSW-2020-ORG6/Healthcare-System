using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class ProcedureTypeDatabaseSql : GenericDatabaseSql<ProcedureType>, IProcedureTypeRepository
    {
        public ProcedureTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<ProcedureType> GetAll()
        {
            return DbContext.ProcedureType.ToList();
        }

        public override ProcedureType GetById(string id)
        {
            return DbContext.ProcedureType.Find(id);
        }
    }
}