using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class EquipmentRelocationDatabaseSql: GenericDatabaseSql<EquipmentRelocation>, IEquipmentRelocationDatabaseSql
    {
        public override List<EquipmentRelocation> GetAll()
        {
            return dbContext.EquipmentRelocations.ToList<EquipmentRelocation>();
        }
        public override EquipmentRelocation GetBySerialNumber(string serialNumber)
        {
            return dbContext.EquipmentRelocations.Find(serialNumber);
        }

        public override void Save(EquipmentRelocation equipmentRelocation)
        {
            dbContext.EquipmentRelocations.Add(equipmentRelocation);
            dbContext.SaveChanges();
        }

        public override void Update(EquipmentRelocation equipmentRelocation)
        {
            dbContext.EquipmentRelocations.Update(equipmentRelocation);
            dbContext.SaveChanges();
        }

        public override void Delete(string serialNumber)
        {
            var equipmentRelocation = GetBySerialNumber(serialNumber);
            if (equipmentRelocation == null) return;
            dbContext.EquipmentRelocations.Remove(equipmentRelocation);
            dbContext.SaveChanges();
        }
    }
}
