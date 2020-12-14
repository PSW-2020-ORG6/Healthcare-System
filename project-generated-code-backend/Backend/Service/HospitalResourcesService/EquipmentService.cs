using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using HealthClinicBackend.Backend.Repository.Generic;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Service.HospitalResourcesService
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Equipment GetById(string id)
        {
            return _equipmentRepository.GetById(id);
        }

        public List<Equipment> GetByName(string name)
        {
            return _equipmentRepository.GetByName(name);
        }

        public List<Equipment> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            _equipmentRepository.Update(equipment);
        }

        public void NewEquipment(Equipment equipment)
        {
            _equipmentRepository.Save(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _equipmentRepository.Delete(equipment.SerialNumber);
        }
    }
}