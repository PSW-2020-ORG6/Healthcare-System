using Model.Accounts;
using System.Collections.Generic;

namespace GraphicEditor.Repositories.Interfaces
{
    public interface ISpecializationRepository
    {
        List<Specialization> GetSpecializationsBySerialNumber(string serialNumber);
        string GetSpecializationsNameBySerialNumber(string serialNumber);
        Specialization GetSpecializationBySerialNumber(string serialNumber);
        List<Specialization> GetSpecializationByName(string name);
    }
}
