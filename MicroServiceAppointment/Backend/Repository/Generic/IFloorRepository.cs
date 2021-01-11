using System.Collections.Generic;
using MicroServiceAppointment.Backend.Model.Hospital;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IFloorRepository : IGenericMsAppointmentRepository<Floor>
    {
        List<Floor> GetByName(string name);
        List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber);
    }
}