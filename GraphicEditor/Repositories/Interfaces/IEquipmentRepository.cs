using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAllEquipments();
        Equipment GetEquipmentsBySerialNumber(string serialNumber);
        List<Equipment> GetEquipmentsByName(string name);
        List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber);
    }
}
