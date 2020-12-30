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
            return DbContext.EquipmentRelocations.ToList<EquipmentRelocation>();
        }
        public override EquipmentRelocation GetBySerialNumber(string serialNumber)
        {
            return DbContext.EquipmentRelocations.Find(serialNumber);
        }

        public override void Save(EquipmentRelocation equipmentRelocation)
        {
            DbContext.EquipmentRelocations.Add(equipmentRelocation);
            DbContext.SaveChanges();
        }

        public override void Update(EquipmentRelocation equipmentRelocation)
        {
            DbContext.EquipmentRelocations.Update(equipmentRelocation);
            DbContext.SaveChanges();
        }

        public override void Delete(string serialNumber)
        {
            var equipmentRelocation = GetBySerialNumber(serialNumber);
            if (equipmentRelocation == null) return;
            DbContext.EquipmentRelocations.Remove(equipmentRelocation);
            DbContext.SaveChanges();
        }
    }
}
