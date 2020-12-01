using health_clinic_class_diagram.Backend.Model.Hospital;
using System.Collections.Generic;

namespace WebApplication.Backend.Repositorys
{
    public interface IFloorRepository
    {
        List<Floor> GetAllFloors();
        List<Floor> GetFloorsByName(string name);
        List<Floor> GetFloorsByBuildingSerialNumber(string buildingSerialNumber);
        Floor GetFloorBySerialNumber(string serialNumber);
    }
}
