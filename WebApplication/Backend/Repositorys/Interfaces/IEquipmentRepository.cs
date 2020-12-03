using Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAllEquipments();
        Equipment GetEquipmentsBySerialNumber(string serialNumber);
        List<Equipment> GetEquipmentsByName(string name);
        List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber);
    }
}
