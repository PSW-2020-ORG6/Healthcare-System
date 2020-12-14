using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class EquipmentController
    {
        public EquipmentService equipmentService;

        public EquipmentController()
        {
            equipmentService = new EquipmentService();
        }

        public Equipment GetById(string id)
        {
            return equipmentService.GetById(id);
        }

        public List<Equipment> GetByName(string name)
        {
            return equipmentService.GetByName(name);
        }

        public List<Equipment> GetAll()
        {
            return equipmentService.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            equipmentService.EditEquipment(equipment);
        }

        public void NewEquipment(Equipment equipment)
        {
            equipmentService.NewEquipment(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            equipmentService.DeleteEquipment(equipment);
        }
    }
}