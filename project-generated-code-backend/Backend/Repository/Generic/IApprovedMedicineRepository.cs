// File:    ApprovedMedicineRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ApprovedMedicineRepository

using HealthClinicBackend.Backend.Model.Hospital;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IApprovedMedicineRepository : IGenericRepository<Medicine>
    {
    }
}