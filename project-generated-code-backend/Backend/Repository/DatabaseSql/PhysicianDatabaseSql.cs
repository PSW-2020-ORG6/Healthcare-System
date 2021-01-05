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
                .Include(p => p.Address)
                .Include(p => p.Address.City)
                .Include(p => p.WorkSchedule)
                .ToList();

            List<PhysicianSpecialization> physicianSpecializations = DbContext.PhysicianSpecialization
                .Include(ps => ps.Physician)
                .ToList();

            foreach (var physician in physicians)
            {
                var specializations = physicianSpecializations
                    .Where(ps => ps.PhysicianSerialNumber.Equals(physician.SerialNumber))
                    .Select(physicianSpecialization => physicianSpecialization.Specialization)
                    .ToList();
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

        public List<Physician> GetByProcedureType(ProcedureType procedureType)
        {
            return GetAll().Where(p => p.Specialization.Contains(procedureType.Specialization)).ToList();
        }

        public List<Physician> GetGeneralPractitioners()
        {
            return GetAll()
                .Where(p => p.Specialization
                    .Select(s => s.Name)
                    .Contains("General Practitioner"))
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