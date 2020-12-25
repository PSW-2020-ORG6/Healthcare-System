using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BedDatabaseSql : GenericDatabaseSql<Bed>, IBedRepository
    {
        public override List<Bed> GetAll()
        {
            return dbContext.Bed.ToList();
        }

        public override Bed GetById(string id)
        {
            return dbContext.Bed.Find(id);
        }

        public List<Bed> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(b => b.RoomSerialNumber.Equals(roomSerialNumber)).ToList();
        }

        public List<Bed> GetByName(string name)
        {
            return GetAll().Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}