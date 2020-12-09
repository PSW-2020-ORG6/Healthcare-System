using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface ISpecializationRepository
    {
        List<Specialization> GetSpecializationsBySerialNumber(string serialNumber); // there is only one ????
        string GetSpecializationsNameBySerialNumber(string serialNumber);
        Specialization GetSpecializationBySerialNumber(string serialNumber);
        List<Specialization> GetSpecializationByName(string name);
    }
}
