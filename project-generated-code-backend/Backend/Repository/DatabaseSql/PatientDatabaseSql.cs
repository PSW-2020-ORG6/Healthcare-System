using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql : GenericDatabaseSql<Patient>, IPatientRepository
    {
        public PatientDatabaseSql() : base()
        {
        }

        public PatientDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Patient> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return DbContext.Patient
                .Include(p => p.Address)
                .Include(p => p.Address.City)
                .Include(p => p.ChosenPhysician)
                .ToList();
        }

        public override void Save(Patient newEntity)
        {
            DbContext.Patient.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Patient updateEntity)
        {
            DbContext.Patient.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public List<Patient> GetPatientsByPhysitian(Physician physician)
        {
            return GetAll().Where(p => p.ChosenPhysician.Equals(physician)).ToList();
        }

        public bool IsPatientIdValid(string id)
        {
            return !GetAll().Any(p => p.Id.Equals(id));
        }

        public Patient GetByJmbg(string jmbg)
        {
            return GetAll().Where(p => p.Id.Equals(jmbg)).ToList()[0];
        }
    }
}