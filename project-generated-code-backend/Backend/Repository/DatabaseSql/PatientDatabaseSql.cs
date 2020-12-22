using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql : GenericDatabaseSql<Patient>, IPatientRepository
    {
        public PatientDatabaseSql() : base()
        {
        }

        public PatientDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Patient> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return dbContext.Patient
                .Include(p => p.Address)
                .Include(p => p.Address.City)
                .Include(p => p.ChosenPhysician)
                .ToList();
        }

        public override void Save(Patient newEntity)
        {
            dbContext.Patient.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Patient updateEntity)
        {
            dbContext.Patient.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public List<Patient> GetPatientsByPhysitian(Physician physician)
        {
            return GetAll().Where(p => p.ChosenPhysician.Equals(physician)).ToList();
        }

        public Patient GetByJmbg(string jbmg)
        {
            return GetAll().Where(p => p.Id.Equals(jbmg)).ToList()[0];
        }

        public bool IsPatientIdValid(string id)
        {
            return !GetAll().Any(p => p.Id.Equals(id));
        }

        public override Patient GetById(string id)
        {
            return GetAll().Where(p => p.Id.Equals(id)).ToList()[0];
        }
    }
}