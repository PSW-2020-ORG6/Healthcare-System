// File:    PatientFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientFileSystem

using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HealthClinicBackend.Backend.Repository.FileSystem
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

        public bool IsPatientIdValid(string id)
        {
            throw new NotImplementedException();
        }

        public Patient GetByJmbg(string jmbg)
        {
            throw new NotImplementedException();
        }

        public override Patient Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Patient>(objectStringFormat);
        }

        public Patient GetPatientByUserNameAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }
    }
}