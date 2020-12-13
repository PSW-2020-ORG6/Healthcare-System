using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IFloorRepository : IGenericRepository<Floor>
    {
        List<Floor> GetByName(string name);
        List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber);
    }
}