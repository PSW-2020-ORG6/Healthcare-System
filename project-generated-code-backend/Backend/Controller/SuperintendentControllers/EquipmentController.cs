using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Service.HospitalResourcesService;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Controller.SuperintendentControllers
{
    public class EquipmentController
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentController()
        {
            _equipmentService = new EquipmentService();
        }

        public Equipment GetById(string id)
        {
            return _equipmentService.GetById(id);
        }

        public List<Equipment> GetByName(string name)
        {
            return _equipmentService.GetByName(name);
        }

        public List<Equipment> GetAll()
        {
            return _equipmentService.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            _equipmentService.EditEquipment(equipment);
        }

        public void NewEquipment(Equipment equipment)
        {
            _equipmentService.NewEquipment(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _equipmentService.DeleteEquipment(equipment);
        }
    }
}