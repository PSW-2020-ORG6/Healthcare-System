// File:    PhysitianFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianFileSystem

using System.Collections.Generic;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Schedule;
using Model.Accounts;
using Newtonsoft.Json;

namespace HealthClinicBackend.Backend.Repository.FileSystem
{
    public class PhysicianFileSystem : GenericFileSystem<Physician>, IPhysitianRepository
    {
        public PhysicianFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/physitians.txt";
            path = @"./../../data/physitians.txt";
        }

        public List<Physician> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Physician GetByJmbg(string jmbg)
        {
            throw new System.NotImplementedException();
        }

        public List<Physician> GetByProcedureType(ProcedureType procedureType)
        {
            List<Physician> physitians = new List<Physician>();
            foreach (Physician physitian in GetAll())
            {
                if (physitian.Specialization.Contains(procedureType.Specialization))
                {
                    physitians.Add(physitian);
                }
            }

            return physitians;
        }

        public List<Physician> GetGeneralPractitioners()
        {
            throw new System.NotImplementedException();
        }

        public override Physician Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Physician>(objectStringFormat);
        }
    }
}