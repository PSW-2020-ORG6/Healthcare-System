// File:    EquipmentFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentFileSystem

using HealthClinicBackend.Backend.Model.Hospital;
using Newtonsoft.Json;

namespace Backend.Repository
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
    }
}