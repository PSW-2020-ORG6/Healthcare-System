using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Service.SchedulingService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller
{
    public class EquipmentRelocationController
    {
        private EquipmentRelocationService EquipmentRelocationService;

        public EquipmentRelocationController()
        {
            EquipmentRelocationService = new EquipmentRelocationService();
        }

        public List<EquipmentRelocation> GetAll()
        {
            return EquipmentRelocationService.GetAll();
        }

        public EquipmentRelocation GetBySerialNumber(string serialNumber)
        {
            return EquipmentRelocationService.GetBySerialNumber(serialNumber);
        }

        public void DeleteEquipmentRelocation(EquipmentRelocation equipmentRelocation)
        {
            EquipmentRelocationService.DeleteEquipmentRelocation(equipmentRelocation);
        }

        public void RelocateEquipmentIfItIsTime()
        {
            EquipmentRelocationService.RelocateEquipmentIfItIsTime();
        }

        public void AddEquipmentRelocation(EquipmentRelocation equipmentRelocation)
        {
            EquipmentRelocationService.AddEquipmentRelocation(equipmentRelocation);
        }
    }
}
