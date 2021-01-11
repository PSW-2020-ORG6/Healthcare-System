using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Model.Util;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.SchedulingService
{
    public class EquipmentRelocationService
    {
        private IEquipmentRelocationDatabaseSql EquipmentRelocationDatabaseSql;
        private RoomDatabaseSql RoomRepository;
        private EquipmentDatabaseSql EquipmentDatabaseSql;
        public EquipmentRelocationService()
        {
            EquipmentRelocationDatabaseSql = new EquipmentRelocationDatabaseSql();
            RoomRepository = new RoomDatabaseSql();
            EquipmentDatabaseSql = new EquipmentDatabaseSql();
        }
        public void AddEquipmentRelocation(EquipmentRelocation equipmentRelocation)
        {
            EquipmentRelocationDatabaseSql.Save(equipmentRelocation);
        }
        public List<EquipmentRelocation> GetAll()
        {
            List<EquipmentRelocation> equipmentRelocations = EquipmentRelocationDatabaseSql.GetAll();
            foreach (EquipmentRelocation equipmentRelocation in equipmentRelocations)
            {
                AddMissingProperties(equipmentRelocation);
            }
            return equipmentRelocations;
        }
        public EquipmentRelocation GetBySerialNumber(string serialNumber)
        {
            EquipmentRelocation equipmentRelocation = EquipmentRelocationDatabaseSql.GetBySerialNumber(serialNumber);
            AddMissingProperties(equipmentRelocation);
            return equipmentRelocation;
        }
        public void RelocateEquipmentIfItIsTime()
        {
            foreach (EquipmentRelocation equipmentRelocation in GetAll())
            {
                if (IsItTimeToMoveEquipment(equipmentRelocation))
                {
                    RelocateEquipment(equipmentRelocation);
                }
            }
        }
        private bool IsItTimeToMoveEquipment(EquipmentRelocation equipmentRelocation)
        {
            if (equipmentRelocation.TimeInterval.IsOverLapping(new TimeInterval(DateTime.Now, DateTime.Now)))
            {
                return true;
            }
            return false;
        }
        private void RelocateEquipment(EquipmentRelocation equipmentRelocation)
        {
            //EquipmentDatabaseSql.GetBySerialNumber(equipmentRelocation.SerialNumber);
            Equipment equipment = EquipmentDatabaseSql.GetBySerialNumber(equipmentRelocation.equipment.SerialNumber);
            if (equipmentRelocation.quantity == equipment.Quantity)
            {
                equipment.RoomSerialNumber = equipmentRelocation.roomToRelocateToSerialNumber;
                EquipmentDatabaseSql.Update(equipment);
                EquipmentRelocationDatabaseSql.Delete(equipmentRelocation.SerialNumber);
            }
            else if (equipmentRelocation.quantity < equipment.Quantity)
            {
                CreateNewEquipment(equipmentRelocation);
                ChangeQuantityOfOldEquipment(equipmentRelocation);
                EquipmentRelocationDatabaseSql.Delete(equipmentRelocation.SerialNumber);
            }
        }

        private void CreateNewEquipment(EquipmentRelocation equipmentRelocation)
        {
            //Equipment equipmentNew = new Equipment(equipmentRelocation.equipment);
            Equipment equipmentNew = new Equipment();
            equipmentNew.Name = equipmentRelocation.equipment.Name;
            equipmentNew.RoomSerialNumber = equipmentRelocation.roomToRelocateToSerialNumber;
            equipmentNew.Quantity = (int)equipmentRelocation.quantity;
            equipmentNew.RoomId = equipmentRelocation.equipment.RoomId;
            equipmentNew.Id = equipmentNew.SerialNumber;
            EquipmentDatabaseSql.Save(equipmentNew);
        }

        private void ChangeQuantityOfOldEquipment(EquipmentRelocation equipmentRelocation)
        {
            Equipment equipmentOld = equipmentRelocation.equipment;
            equipmentOld.Quantity -= (int)equipmentRelocation.quantity;
            EquipmentDatabaseSql.Update(equipmentOld);
        }

        private void AddMissingProperties(EquipmentRelocation equipmentRelocation)
        {
            equipmentRelocation.equipment = EquipmentDatabaseSql.GetBySerialNumber(equipmentRelocation.equipmentSerialNumber);
        }
    }
}
