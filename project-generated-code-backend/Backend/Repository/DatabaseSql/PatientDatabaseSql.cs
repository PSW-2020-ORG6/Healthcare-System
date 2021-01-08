using HealthClinicBackend.Backend.Model.Accounts;
using HealthClinicBackend.Backend.Repository.Generic;
using Model.Accounts;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql : GenericDatabaseSql<Patient>, IPatientRepository
    {
        public override List<Patient> GetAll()
        {
            return dbContext.Patient.ToList();
        }

        public override Patient GetById(string id)
        {
            return dbContext.Patient.Find(id);
        }

        public List<Patient> GetByName(string name)
        {
            return GetAll().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
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