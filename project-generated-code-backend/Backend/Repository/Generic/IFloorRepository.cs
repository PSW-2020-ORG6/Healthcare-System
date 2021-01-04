using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IFloorRepository : IGenericRepository<Floor>
    {
        List<Floor> GetByName(string name);
        List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber);
    }
}