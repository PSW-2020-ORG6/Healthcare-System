using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IBuildingRepository
    {
        List<Building> GetAllBuildings();
        List<Building> GetBuildingsByName(string name);
        Building GetBuildingBySerialNumber(string serialNumber);
    }
}
