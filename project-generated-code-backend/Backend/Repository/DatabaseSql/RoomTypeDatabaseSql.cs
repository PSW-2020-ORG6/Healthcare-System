using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomTypeDatabaseSql : GenericDatabaseSql<RoomType>, IRoomTypeRepository
    {
        public override List<RoomType> GetAll()
        {
            return dbContext.RoomType.ToList();
        }

        public List<RoomType> GetByName(string name)
        {
            return GetAll().Where(rt => rt.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public override RoomType GetById(string id)
        {
            return dbContext.RoomType.Find(id);
        }

        public override void Save(RoomType newEntity)
        {
            dbContext.RoomType.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(RoomType updateEntity)
        {
            dbContext.RoomType.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var roomType = GetById(id);
            if (roomType == null) return;
            dbContext.RoomType.Remove(roomType);
            dbContext.SaveChanges();
        }
    }
}