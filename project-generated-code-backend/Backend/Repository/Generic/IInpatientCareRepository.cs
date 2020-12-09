// File:    InpatientCareRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface InpatientCareRepository

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.MedicalExam;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IInpatientCareRepository : IGenericRepository<InpatientCare>
    {
        List<InpatientCare> GetInpatientCaresForPatient(Patient patient);

    }
}