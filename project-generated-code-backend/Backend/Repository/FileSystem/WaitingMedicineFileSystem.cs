// File:    WaitingMedicineFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class WaitingMedicineFileSystem

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class WaitingMedicineFileSystem : GenericFileSystem<Medicine>, IWaitingMedicineRepository
    {
        public WaitingMedicineFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/waiting_medicine.txt";
            path = @"./../../data/waiting_medicine.txt";
        }

        public override Medicine Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Medicine>(objectStringFormat);
        }
    }
}