// File:    PhysitianRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PhysitianRepository

using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.Generic
{
    public interface IPhysicianRepository : IGenericRepository<Physician>
    {
        List<Physician> GetByName(string name);
        Physician GetByJmbg(string jmbg);
        List<Physician> GetByProcedureType(ProcedureType procedureType);
        List<Physician> GetGeneralPractitioners();
    }
}