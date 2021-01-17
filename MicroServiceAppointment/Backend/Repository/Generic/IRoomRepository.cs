using MicroServiceAppointment.Backend.Model;
using MicroServiceAppointment.Backend.Model.Hospital;
using System.Collections.Generic;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IRoomRepository : IGenericMsAppointmentRepository<Room>
    {
        List<Room> GetByRoomType(RoomType roomType);
        List<Room> GetByName(string name);
        List<Room> GetByFloorSerialNumber(string floorSerialNumber);
        List<Room> GetByProcedureType(ProcedureType procedureType);
        Room GetBySerialNumber(string serialNumber);
        Room GetByPosition(Position position);
    }
}