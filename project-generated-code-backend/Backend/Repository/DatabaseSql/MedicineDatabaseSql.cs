using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineDatabaseSql : GenericDatabaseSql<Medicine>
    {
        public override List<Medicine> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return dbContext.Medicine
                .Include(m => m.MedicineManufacturer)
                .Include(m => m.MedicineType)
                .ToList();
        }
    }
}