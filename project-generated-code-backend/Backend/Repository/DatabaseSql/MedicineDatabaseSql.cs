﻿using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineDatabaseSql : GenericDatabaseSql<Medicine>, IMedicineRepository
    {
        public override List<Medicine> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return dbContext.Medicine
                .Include(m => m.MedicineManufacturer)
                .Include(m => m.MedicineType)
                .ToList();
        }

        public override Medicine GetById(string id)
        {
            return dbContext.Medicine.Find(id);
        }

        public override void Save(Medicine newEntity)
        {
            dbContext.Medicine.Add(newEntity);
            dbContext.SaveChanges();
        }

        public override void Update(Medicine updateEntity)
        {
            dbContext.Medicine.Update(updateEntity);
            dbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var medicine = GetById(id);
            if (medicine == null) return;
            dbContext.Medicine.Remove(medicine);
            dbContext.SaveChanges();
        }

        public List<Medicine> GetApproved()
        {
            return GetAll().Where(m => m.IsApproved).ToList();
        }

        public List<Medicine> GetWaiting()
        {
            return GetAll().Where(m => !m.IsApproved).ToList();
        }

        public List<Medicine> GetByName(string name)
        {
            return GetAll().Where(m => m.CopyrightName.ToLower().Contains(name.ToLower()) || m.CopyrightName.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}