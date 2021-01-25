using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
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
            return DbContext.Equipment.ToList();
        }

        public override Equipment GetById(string id)
        {
            return DbContext.Equipment.Find(id);
        }

        public List<Equipment> GetByName(string name)
        {
            return GetAll().Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Equipment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            return GetAll().Where(e => e.RoomSerialNumber.Equals(roomSerialNumber)).ToList();
        }

        public override void Save(Equipment newEntity)
        {
            bool entered = false;
            foreach (Equipment equipment in DbContext.Equipment)
            {
                if (equipment.Name.ToLower().Equals(newEntity.Name.ToLower()) && equipment.RoomSerialNumber.Equals(newEntity.RoomSerialNumber))
                {
                    entered = true;
                    equipment.Quantity += newEntity.Quantity;
                    DbContext.Equipment.Update(equipment);
                }
            }
            if (!entered)
                DbContext.Equipment.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Equipment updateEntity)
        {
            DbContext.Equipment.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var equipment = GetById(id);
            if (equipment == null) return;
            DbContext.Equipment.Remove(equipment);
            DbContext.SaveChanges();
        }
    }
}