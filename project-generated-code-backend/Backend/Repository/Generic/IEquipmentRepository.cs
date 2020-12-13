// File:    EquipmentRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface EquipmentRepository

using HealthClinicBackend.Backend.Model.Hospital;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IEquipmentRepository : IGenericRepository<Equipment>
    {
        List<Equipment> GetByName(string name);
        List<Equipment> GetByRoomSerialNumber(string roomSerialNumber);
    }
}