using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using Model.Hospital;
using Model.Schedule;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomDatabaseSql: GenericDatabaseSql<Room>, IRoomRepository
    {
        public override List<Room> GetAll()
        {
            return dbContext.Rooms.ToList();
        }

        public override void Save(Room newEntity)
        {
            dbContext.Rooms.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Room updateEntity)
        {
            dbContext.Rooms.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public void Delete(Room entity)
        {
            dbContext.Rooms.Remove(entity);
            dbContext.SaveChanges();
        }

        public override Room GetById(string id)
        {
            return dbContext.Rooms.Find(id);
        }

        public List<Room> GetRoomsByProcedureType(ProcedureType procedureType)
        {
            throw new System.NotImplementedException();
        }

        public List<Room> GetRoomsByRoomType(RoomType roomType)
        {
            throw new System.NotImplementedException();
        }
    }
}