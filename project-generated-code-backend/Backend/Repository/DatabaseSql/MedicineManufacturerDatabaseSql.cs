using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineManufacturerDatabaseSql : GenericDatabaseSql<MedicineManufacturer>, IMedicineManufacturerRepository
    {
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