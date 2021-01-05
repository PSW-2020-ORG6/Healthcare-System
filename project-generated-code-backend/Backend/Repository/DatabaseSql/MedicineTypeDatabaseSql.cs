using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineTypeDatabaseSql : GenericDatabaseSql<MedicineType>, IMedicineTypeRepository
    {
        public MedicineTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}