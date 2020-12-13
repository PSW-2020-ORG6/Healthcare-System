// File:    RoomRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface RoomRepository

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
    }
}