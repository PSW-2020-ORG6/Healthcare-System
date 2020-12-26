using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PhysicianDatabaseSql : GenericDatabaseSql<Physician>, IPhysitianRepository
    {
        private SpecializationDatabaseSql specializationDatabaseSql = new SpecializationDatabaseSql();
        public override List<Physician> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            List<Physician> physicians = dbContext.Physician
                .ToList();

            List<PhysicianSpecialization> physicianSpecializations = dbContext.PhysicianSpecialization
                .ToList();

            foreach (var physician in physicians)
            {
                var specializationsSN = physicianSpecializations
                    .Where(ps => ps.PhysicianSerialNumber.Equals(physician.SerialNumber))
                    .Select(physicianSpecialization => physicianSpecialization.SpecializationSerialNumber)
                    .ToList();
                var specializations = new List<Specialization>();
                foreach( string sn in specializationsSN )
                {
                    specializations.Add(specializationDatabaseSql.GetById(sn));
                }
                physician.Specialization = specializations;
            }

            return physicians;
        }

        public List<Physician> GetByName(string name)
        {
            return GetAll().Where(p => p.Name.Equals(name)).ToList();
        }

        public Physician GetByJmbg(string jmbg)
        {
            return GetAll().Where(p => p.Id.Equals(jmbg)).ToList()[0];
        }

        public List<Physician> GetByProcedureType(ProcedureType procedureType)
        {
            return GetAll().Where(p => p.Specialization.Contains(procedureType.Specialization)).ToList();
        }

        public override Physician GetById(string id)
        {
            return GetAll().Where(p => p.SerialNumber.Equals(id)).ToList()[0];
        }

        public List<Physician> GetGeneralPractitioners()
        {
            return GetAll()
                .Where(p => p.Specialization
                    .Select(s => s.Name)
                    .Contains("General Practitioner"))
                .ToList();
        }

    }
}