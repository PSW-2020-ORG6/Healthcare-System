// File:    PhysitianRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PhysitianRepository

using MicroServiceAccount.Backend.Model;
using System.Collections.Generic;

namespace MicroServiceAccount.Backend.Repository.Generic
{
    public interface IPhysicianRepository : IGenericMsAccountRepository<Physician>
    {
        List<Physician> GetByName(string name);
        Physician GetByJmbg(string jmbg);
        //List<Physician> GetByProcedureType(ProcedureType procedureType);
        List<Physician> GetGeneralPractitioners();
        List<Physician> GetBySpecializationName(string name);
    }
}