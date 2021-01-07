using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        List<Room> GetByRoomType(RoomType roomType);
        List<Room> GetByName(string name);
        List<Room> GetByFloorSerialNumber(string floorSerialNumber);
        List<Room> GetByProcedureType(ProcedureType procedureType);
        Room GetBySerialNumber(string serialNumber);
        Room GetByPositionSerialNumber(string positionSerialNumber);
    }
}