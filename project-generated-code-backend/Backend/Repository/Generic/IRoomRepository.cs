// File:    RoomRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface RoomRepository

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Model.Schedule;

namespace Backend.Repository
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        List<Room> GetRoomsByProcedureType(ProcedureType procedureType);
        List<Room> GetRoomsByRoomType(RoomType roomType);
    }
}