using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineManufacturerDatabaseSql: GenericDatabaseSql<MedicineManufacturer>, IMedicineManufacturerRepository
    {
        public MedicineManufacturerDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }
        public override List<MedicineManufacturer> GetAll()
        {
            return dbContext.MedicineManufacturer.ToList();
        }

        public override MedicineManufacturer GetById(string id)
        {
            return dbContext.MedicineManufacturer.Find(id);
        }
    }
}