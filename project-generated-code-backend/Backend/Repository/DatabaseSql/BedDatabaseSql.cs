using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BedDatabaseSql : GenericDatabaseSql<Bed>, IBedRepository
    {
        public BedDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }
        public override List<Bed> GetAll()
        {
            return dbContext.Bed.ToList();
        }

        public List<Bed> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(b => b.RoomSerialNumber.Equals(roomSerialNumber)).ToList();
        }

    }
}