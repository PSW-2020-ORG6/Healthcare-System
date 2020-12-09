using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace WebApplication.Backend.Repositorys.Interfaces
{
    public interface IFloorRepository
    {
        List<Floor> GetAllFloors();
        List<Floor> GetFloorsByName(string name);
        List<Floor> GetFloorsByBuildingSerialNumber(string buildingSerialNumber);
        Floor GetFloorBySerialNumber(string serialNumber);

    }
}
