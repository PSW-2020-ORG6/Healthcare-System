using MicroServiceAppointment.Backend.Model.Hospital;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IFloorRepository : IGenericMsAppointmentRepository<Floor>
    {
        List<Floor> GetByName(string name);
        List<Floor> GetByBuildingSerialNumber(string buildingSerialNumber);
        Floor GetBySerialNumber(string serialNumber);
    }
}