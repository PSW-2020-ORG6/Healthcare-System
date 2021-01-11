// File:    RoomRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface RoomRepository

using System.Collections.Generic;
using MicroServiceAppointment.Backend.Model.Hospital;
using MicroServiceAppointment.Backend.Model;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IRoomRepository : IGenericMsAppointmentRepository<Room>
    {
        List<Room> GetByProcedureType(ProcedureType procedureType);
        List<Room> GetByRoomType(RoomType roomType);
        List<Room> GetByName(string name);
        List<Room> GetByFloorSerialNumber(string floorSerialNumber);
    }
}