
using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Repository.Generic;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class MedicineTypeDatabaseSql : GenericMsAppointmentDatabaseSql<MedicineType>, IMedicineTypeRepository
    {
        public MedicineTypeDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
        {
        }
    }
}