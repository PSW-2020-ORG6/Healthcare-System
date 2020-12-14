using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class EquipmentDatabaseSql : GenericDatabaseSql<Equipment>, IEquipmentRepository
    {
        public EquipmentDatabaseSql() : base()
        {
        }

        public EquipmentDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Equipment> GetAll()
        {
            return dbContext.Equipment.ToList();
        }

        public override Equipment GetById(string id)
        {
            return dbContext.Equipment.Find(id);
        }

        public override void Save(Equipment newEntity)
        {
            dbContext.Equipment.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Equipment updateEntity)
        {
            dbContext.Equipment.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var equipment = GetById(id);
            if (equipment == null) return;
            dbContext.Equipment.Remove(equipment);
            dbContext.SaveChanges();
        }

        public List<Equipment> GetByName(string name)
        {
            return GetAll().Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Equipment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(e => e.RoomSerialNumber.Equals(roomSerialNumber)).ToList();
        }
    }
}