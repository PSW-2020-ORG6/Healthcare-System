using Model.Hospital;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAllEquipments();
        List<Equipment> GetEquipmentsByName(string name);
        List<Equipment> GetEquipmentsByRoomSerialNumber(string roomSerialNumber);
    }
}
