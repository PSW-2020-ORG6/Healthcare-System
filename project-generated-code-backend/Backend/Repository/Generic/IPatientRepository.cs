// File:    PatientRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PatientRepository

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        List<Patient> GetPatientsByPhysitian(Physician physician);
        bool IsPatientIdValid(string id);
        Patient GetByJmbg(string jmbg);
        Patient GetPatientByUserNameAndPassword(string email, string password);
        List<Patient> GetAllPatients();
        Patient GetById(string id);
        Patient GetPatientBySerialNumber(string serialNumber);

    }
}