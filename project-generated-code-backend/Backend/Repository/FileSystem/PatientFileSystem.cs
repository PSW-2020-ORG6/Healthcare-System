// File:    PatientFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientFileSystem

using Model.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class PatientFileSystem : GenericFileSystem<Patient>, IPatientRepository
    {
        public PatientFileSystem()
        {
            path = @"./../../data/patients.txt";
        }
        public List<Patient> GetPatientsByPhysitian(Physician physician)
        {
            throw new NotImplementedException();
        }

        public override Patient Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Patient>(objectStringFormat);
        }
    }
}