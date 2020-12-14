using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql : GenericDatabaseSql<Patient>, IPatientRepository
    {
        public override List<Patient> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return dbContext.Patient
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
    }
}