// File:    PatientRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PatientRepository

using MicroServiceAccount.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceAccount.Backend.Repository.Generic
{
    public interface IPatientRepository : IGenericMsAccountRepository<Patient>
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