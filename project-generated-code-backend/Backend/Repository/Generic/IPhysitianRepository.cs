// File:    PhysitianRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PhysitianRepository

using Model.Accounts;
using System.Collections.Generic;
using HealthClinicBackend.Backend.Model.Schedule;

namespace Backend.Repository
{
    public interface IPhysitianRepository : IGenericRepository<Physician>
    {
        List<Physician> GetByName(string name);
        Physician GetByJmbg(string jmbg);
        List<Physician> GetByProcedureType(ProcedureType procedureType);
        List<Physician> GetGeneralPractitioners();
    }
}