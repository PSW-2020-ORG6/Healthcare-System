using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class RoomTypeDatabaseSql : GenericDatabaseSql<RoomType>, IRoomTypeRepository
    {
        public RoomTypeDatabaseSql() : base()
        {
        }

        public RoomTypeDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<RoomType> GetAll()
        {
            return DbContext.RoomType.ToList();
        }

        public List<RoomType> GetByName(string name)
        {
            return GetAll().Where(rt => rt.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public override RoomType GetById(string id)
        {
            return DbContext.RoomType.Find(id);
        }

        public override void Save(RoomType newEntity)
        {
            DbContext.RoomType.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(RoomType updateEntity)
        {
            DbContext.RoomType.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var roomType = GetById(id);
            if (roomType == null) return;
            DbContext.RoomType.Remove(roomType);
            DbContext.SaveChanges();
        }
    }
}