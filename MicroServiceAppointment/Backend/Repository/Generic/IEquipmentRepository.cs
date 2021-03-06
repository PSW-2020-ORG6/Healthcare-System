// File:    EquipmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface EquipmentRepository

using System.Collections.Generic;
using MicroServiceAppointment.Backend.Model.Hospital;

namespace MicroServiceAppointment.Backend.Repository.Generic
{
    public interface IEquipmentRepository : IGenericMsAppointmentRepository<Equipment>
    {
        List<Equipment> GetByName(string name);
        List<Equipment> GetByRoomSerialNumber(string roomSerialNumber);
    }
}