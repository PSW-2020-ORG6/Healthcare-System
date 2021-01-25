using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineManufacturerDatabaseSql : GenericDatabaseSql<MedicineManufacturer>,
        IMedicineManufacturerRepository
    {
        public MedicineManufacturerDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<MedicineManufacturer> GetAll()
        {
            return DbContext.MedicineManufacturer.ToList();
        }

        public override MedicineManufacturer GetById(string id)
        {
            return DbContext.MedicineManufacturer.Find(id);
        }
    }
}