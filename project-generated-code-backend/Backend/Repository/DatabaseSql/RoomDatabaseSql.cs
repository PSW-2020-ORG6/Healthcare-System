using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomDatabaseSql: GenericDatabaseSql<Room>, IRoomRepository
    {
        public override List<Room> GetAll()
        {
            return dbContext.Room
                .Include(r => r.Floor)
                .Include(r => r.RoomType)
                .Include(r => r.Equipment)
                .Include(r => r.Beds)
                .ToList();
        }
        
        public override Room GetById(string id)
        {
            return GetAll().Where(r => r.SerialNumber.Equals(id)).ToList()[0];
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