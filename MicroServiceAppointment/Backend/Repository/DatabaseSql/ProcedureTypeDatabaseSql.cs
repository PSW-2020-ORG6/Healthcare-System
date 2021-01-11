using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class ProcedureTypeDatabaseSql : GenericMsAppointmentDatabaseSql<ProcedureType>, IProcedureTypeRepository
    {
        public ProcedureTypeDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
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