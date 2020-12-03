using Model.Accounts;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IPhysitianRepository
    {
        List<Physitian> GetAllPhysitians();
        List<Physitian> GetPhysitiansByName(string name);
        List<Physitian> GetPhysitiansByFullName(string fullName);
        Physitian GetPhysitianBySerialNumber(string serialNumber);
        Physitian GetPhysitianById(string id);
    }
}
