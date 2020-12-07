// File:    PhysitianFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianFileSystem

using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class PhysicianFileSystem : GenericFileSystem<Physician>, IPhysitianRepository
    {
        public PhysicianFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/physitians.txt";
            path = @"./../../data/physitians.txt";

        }

        public List<Physician> GetPhysitiansByProcedureType(ProcedureType procedureType)
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