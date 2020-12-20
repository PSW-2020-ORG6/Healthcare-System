using Model.Accounts;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IPhysicianRepository
    {
        List<Physician> GetAllPhysicians();
        List<Physician> GetPhysiciansByName(string name);
        List<Physician> GetPhysiciansByFullName(string fullName);
        Physician GetPhysicianBySerialNumber(string serialNumber);
        Physician GetPhysicianById(string id);
        List<Physician> GetPhysicianBySpecialization(string specializationName, string physicianId);
    }
}
