﻿using System.Collections.Generic;
using System.Linq;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Accounts;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PatientDatabaseSql: GenericDatabaseSql<Patient>, IPatientRepository
    {
        public override List<Patient> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return dbContext.Patient
                .Include(p => p.Address)
                .Include(p => p.Address.City)
                .Include(p => p.ChosenPhysician)
                .ToList();
        }

        public List<Patient> GetPatientsByPhysitian(Physician physician)
        {
            return GetAll().Where(p => p.ChosenPhysician.Equals(physician)).ToList();
        }
    }
}