using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAllEquipments();
        List<Equipment> GetEquipmentsByName(string name);
    }
}
