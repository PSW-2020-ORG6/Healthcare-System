// File:    RejectionFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RejectionFileSystem

using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class RejectionFileSystem : GenericFileSystem<Rejection>, IRejectionRepository
    {
        public RejectionFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/rejections.txt";
            path = @"./../../data/rejections.txt";
        }
        public override Rejection Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Rejection>(objectStringFormat);
        }
    }
}