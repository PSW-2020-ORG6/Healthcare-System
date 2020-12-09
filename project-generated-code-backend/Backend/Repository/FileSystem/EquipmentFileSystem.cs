// File:    EquipmentFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentFileSystem

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class EquipmentFileSystem : GenericFileSystem<Equipment>, IEquipmentRepository
    {
        public EquipmentFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/equipment.txt";
            path = @"./../../data/equipment.txt";

        }
        public override Equipment Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Equipment>(objectStringFormat);
        }

        public List<Equipment> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Equipment> GetByRoomSerialNumber(string roomSerialNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}