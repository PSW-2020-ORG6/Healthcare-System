using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class MedicineManufacturerDatabaseSql : GenericMsAppointmentDatabaseSql<MedicineManufacturer>,
        IMedicineManufacturerRepository
    {
        public MedicineManufacturerDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
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