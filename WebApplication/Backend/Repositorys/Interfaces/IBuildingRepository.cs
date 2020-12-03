using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IBuildingRepository
    {
        List<Building> GetAllBuildings();
        List<Building> GetBuildingsByName(string name);
        Building GetBuildingBySerialNumber(string serialNumber);
    }
}
