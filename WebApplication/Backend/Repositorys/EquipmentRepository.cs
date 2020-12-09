using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.DatabaseSql;
using WebApplication.Backend.Repositorys.Interfaces;

namespace WebApplication.Backend.Repositorys
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private EquipmentDatabaseSql _equipmentRepository;

        public EquipmentRepository()
        {
            _equipmentRepository = new EquipmentDatabaseSql();
        }

        public List<Equipment> GetAllEquipments()
        {
            return _equipmentRepository.GetAll();
        }

        public Equipment GetEquipmentsBySerialNumber(string serialNumber)
        {
            return _equipmentRepository.GetById(serialNumber);
        }

        public List<Equipment> GetEquipmentsByName(string name)
        {
            return _equipmentRepository.GetByName(name);
        }

        public List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber)
        {
            return _equipmentRepository.GetByRoomSerialNumber(roomSerialNumber);
        }
    }
}