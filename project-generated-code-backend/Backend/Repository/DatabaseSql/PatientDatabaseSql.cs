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
            return DbContext.Patient.ToList();
        }

        public override Patient GetById(string id)
        {
            return DbContext.Patient.Find(id);
        }

        public List<Patient> GetByName(string name)
        {
            return GetAll().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
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

        public Patient GetPatientByUserNameAndPassword(string email, string password)
        {
            List<Patient> patients = GetAll().Where(p => p.Email.Equals(email) && p.Password.Equals(password)).ToList();
            if (patients.Count == 0)
            {
                return null;
            }
            else
            {
                return patients[0];
            }
        }

        public List<Patient> GetAllPatients()
        {
            return GetAll();
        }

        public Patient GetPatientBySerialNumber(string serialNumber)
        {
            return GetAll().Where(p => p.SerialNumber.Equals(serialNumber)).ToList()[0];
        }
    }
}