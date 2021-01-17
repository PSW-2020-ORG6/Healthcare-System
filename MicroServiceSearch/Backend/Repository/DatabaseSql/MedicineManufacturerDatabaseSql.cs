using MicroServiceAppointment.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class MedicineManufacturerDatabaseSql : GenericMsSearchDatabaseSql<MedicineManufacturer>,
        IMedicineManufacturerRepository
    {
        public MedicineManufacturerDatabaseSql(MsSearchDbContext dbContext) : base(dbContext)
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