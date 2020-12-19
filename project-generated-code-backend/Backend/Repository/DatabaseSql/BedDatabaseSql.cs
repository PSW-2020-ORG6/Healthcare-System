using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BedDatabaseSql: GenericDatabaseSql<Bed>, IBedRepository
    {
        public BedDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }
        public override List<Bed> GetAll()
        {
            return dbContext.Bed
                .Include(b => b.Building)
                .Include(b => b.Floor)
                .Include(b => b.Room)
                .Include(b => b.Patient)
                .ToList();
        }
    }
}