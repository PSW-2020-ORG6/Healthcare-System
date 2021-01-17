
using MicroServiceAppointment.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class MedicineTypeDatabaseSql : GenericMsSearchDatabaseSql<MedicineType>, IMedicineTypeRepository
    {
        public MedicineTypeDatabaseSql(MsSearchDbContext dbContext) : base(dbContext)
        {
        }
    }
}