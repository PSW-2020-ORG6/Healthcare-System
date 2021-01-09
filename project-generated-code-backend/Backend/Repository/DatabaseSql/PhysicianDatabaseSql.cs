using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PhysicianDatabaseSql : GenericDatabaseSql<Physician>, IPhysicianRepository
    {
        public PhysicianDatabaseSql() : base()
        {
        }

        public PhysicianDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Physician> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            List<Physician> physicians = DbContext.Physician
                .ToList();

            List<PhysicianSpecialization> physicianSpecializations = DbContext.PhysicianSpecialization
                .ToList();

            foreach (var physician in physicians)
            {
                var specializationsSN = physicianSpecializations
                    .Where(ps => ps.PhysicianSerialNumber.Equals(physician.SerialNumber))
                    .Select(physicianSpecialization => physicianSpecialization.SpecializationSerialNumber)
                    .ToList();
                var specializations = new List<Specialization>();
                foreach (string sn in specializationsSN)
                {
                    specializations.Add(DbContext.Specialization.Find(sn));
                }
                physician.Specialization = specializations;
            }

            return physicians;
        }

        public List<Physician> GetByName(string name)
        {
            return GetAll().Where(p => (p.Name + " " + p.Surname).Equals(name)).ToList();
        }

        public Physician GetByJmbg(string jmbg)
        {
            return GetAll().Where(p => p.Id.Equals(jmbg)).ToList()[0];
        }
        
        public override Physician GetById(string jmbg)
        {
            return GetAll().Where(p => p.Id.Equals(jmbg) || p.SerialNumber.Equals(jmbg)).ToList()[0];
        }


        public List<Physician> GetByProcedureType(ProcedureType procedureType)
        {
            return GetAll().Where(p => p.Specialization.Contains(procedureType.Specialization)).ToList();
        }

        public List<Physician> GetGeneralPractitioners()
        {
            return GetAll()
                .Where(p => p.Specialization
                    .Select(s => s.Name)
                    .Contains("General practitioner"))
                .ToList();
        }

        public List<Physician> GetBySpecializationName(string name)
        {
            return GetAll()
                .Where(p => p.Specialization
                    .Any(s => s.Name.ToLower().Equals(name.ToLower())))
                .ToList();
        }
    }
}