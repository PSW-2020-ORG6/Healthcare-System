using System.Collections.Generic;
using System.Linq;
using MicroServiceAccount.Backend.Repository.DatabaseSql;
using Microsoft.EntityFrameworkCore;
using MicroServiceAccount.Backend.Repository.Generic;
using MicroServiceAccount.Backend.Model;

namespace MicroServiceAccount.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql : GenericMsAccountDatabaseSql<Patient>, IPatientRepository
    {
        public PatientDatabaseSql() : base()
        {
        }

        public PatientDatabaseSql(MsAccountDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Patient> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return DbContext.Patient
                .Include(p => p.Address)
                .ThenInclude(p => p.City)
                //.Include(p => p.ChosenPhysician)
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

        public Patient GetPatientByUserNameAndPassword(string email, string password)
        {
            List<Patient> patients = GetAll().Where(p => p.Email.Equals(email) && p.Password.Equals(password)).ToList();
            if (patients.Count == 0)
                return null;
            else
                return patients[0];
        }

        public List<Patient> GetAllPatients()
        {
            return GetAll();
        }

        public override Patient GetById(string id)
        {
            List<Patient> patients = GetAll().Where(p => p.Id.Equals(id)).ToList();
            if (patients.Count == 0)
                return null;
            else
                return patients[0];
        }

        public Patient GetPatientBySerialNumber(string serialNumber)
        {
            return GetAll().Where(p => p.SerialNumber.Equals(serialNumber)).ToList()[0];
        }
    }
}