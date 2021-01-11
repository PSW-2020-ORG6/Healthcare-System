using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class BedDatabaseSql : GenericDatabaseSql<Bed>, IBedRepository
    {
        public BedDatabaseSql() : base()
        {
        }

        public BedDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }
        public override List<Bed> GetAll()
        {
            return DbContext.Bed.ToList();
        }

        public override Bed GetById(string id)
        {
            return DbContext.Bed.Find(id);
        }

        public List<Bed> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(b => b.RoomSerialNumber.Equals(roomSerialNumber)).ToList();
        }

        public List<Bed> GetByName(string name)
        {
            return GetAll().Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public override void Delete(string id)
        {
            var bed = GetById(id);
            if (bed == null) return;
            DbContext.Bed.Remove(bed);
            DbContext.SaveChanges();
        }

        public override void Save(Bed newEntity)
        {
            DbContext.Bed.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Bed updateEntity)
        {
            DbContext.Bed.Update(updateEntity);
            DbContext.SaveChanges();
        }
    }
}