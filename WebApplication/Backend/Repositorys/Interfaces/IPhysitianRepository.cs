using Model.Accounts;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IPhysitianRepository
    {
        List<Physician> GetAllPhysitians();
        List<Physician> GetPhysitiansByName(string name);
        List<Physician> GetPhysitiansByFullName(string fullName);
        Physician GetPhysitianBySerialNumber(string serialNumber);
        Physician GetPhysitianById(string id);
    }
}
