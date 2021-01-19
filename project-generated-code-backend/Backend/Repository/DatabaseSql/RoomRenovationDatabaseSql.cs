using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomRenovationDatabaseSql : GenericDatabaseSql<RoomRenovation>, IRoomRenovationRepository
    {
        public RoomRenovationDatabaseSql() : base()
        {
        }

        public RoomRenovationDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<RoomRenovation> GetAll()
        {
            return DbContext.RoomRenovations.ToList();
        }

        public override RoomRenovation GetById(string id)
        {
            return DbContext.RoomRenovations.Find(id);
        }


        public override void Save(RoomRenovation newEntity)
        {
            DbContext.RoomRenovations.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(RoomRenovation updateEntity)
        {
            DbContext.RoomRenovations.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var roomRenovation = GetById(id);
            if (roomRenovation == null) return;
            DbContext.RoomRenovations.Remove(roomRenovation);
            DbContext.SaveChanges();
        }

        public override RoomRenovation GetBySerialNumber(string serialNumber)
        {
            return DbContext.RoomRenovations.Find(serialNumber);
        }

        public List<RoomRenovation> GetByTimeInterval(string roomRenovationSerialNumber)
        {
            throw new NotImplementedException();
        }
    }
}
