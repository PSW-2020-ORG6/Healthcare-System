using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomDatabaseSql : GenericDatabaseSql<Room>, IRoomRepository
    {
        public RoomDatabaseSql() : base()
        {
        }

        public RoomDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Room> GetAll()
        {
            return DbContext.Room.ToList();
        }

        public override Room GetById(string id)
        {
            return DbContext.Room.Find(id);
        }

        public override void Save(Room newEntity)
        {
            DbContext.Room.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Room updateEntity)
        {
            DbContext.Room.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var room = GetById(id);
            if (room == null) return;
            DbContext.Room.Remove(room);
            DbContext.SaveChanges();
        }

        public override Room GetBySerialNumber(string serialNumber)
        {
            return GetAll().Where(r => r.SerialNumber.Equals(serialNumber)).ToList()[0];
        }

        public List<Room> GetByRoomType(RoomType roomType)
        {
            return GetAll().Where(r => r.RoomType.Equals(roomType)).ToList();
        }

        public List<Room> GetByName(string name)
        {
            return GetAll().Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Room> GetByFloorSerialNumber(string floorSerialNumber)
        {
            return GetAll().Where(r => r.FloorSerialNumber.Equals(floorSerialNumber)).ToList();
        }

        public List<Room> GetByProcedureType(ProcedureType procedureType)
        {
            return GetAll(); //TO DO
        }
    }
}