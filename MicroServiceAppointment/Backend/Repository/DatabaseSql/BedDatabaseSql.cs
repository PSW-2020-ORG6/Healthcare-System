using System.Collections.Generic;
using System.Linq;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceAppointment.Backend.Repository.DatabaseSql
{
    public class BedDatabaseSql: GenericMsAppointmentDatabaseSql<Bed>, IBedRepository
    {
        public BedDatabaseSql(MsAppointmentDbContext dbContext) : base(dbContext)
        {
        }
        public override List<Bed> GetAll()
        {
            return DbContext.Bed
                .Include(b => b.Building)
                .Include(b => b.Floor)
                .Include(b => b.Room)
                .Include(b => b.Patient)
                .ToList();
        }
    }
}