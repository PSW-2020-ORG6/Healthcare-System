using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using HealthClinicBackend.Backend.Model.Schedule;
using HealthClinicBackend.Backend.Repository.DatabaseSql.RelationHelpers;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PhysicianDatabaseSql : GenericDatabaseSql<Physician>, IPhysitianRepository
    {
        public override List<Physician> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            List<Physician> physicians = dbContext.Physician
                .Include(p => p.Address)
                .Include(p => p.Address.City)
                .Include(p => p.WorkSchedule)
                .ToList();

            List<PhysicianSpecialization> physicianSpecializations = dbContext.PhysicianSpecialization
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

        public List<Physician> GetPhysitiansByProcedureType(ProcedureType procedureType)
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
    }
}