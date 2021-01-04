// File:    ApprovedMedicineFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ApprovedMedicineFileSystem

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class ApprovedMedicineFileSystem : GenericFileSystem<Medicine>, IApprovedMedicineRepository
    {
        public ApprovedMedicineFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/approved_medicine.txt";
            path = @"./../../data/approved_medicine.txt";

        }
        public override Medicine Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Medicine>(objectStringFormat);
        }
    }
}