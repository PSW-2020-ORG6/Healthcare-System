using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.Hospital;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class MedicineDatabaseSql : GenericDatabaseSql<Medicine>, IMedicineRepository
    {
        public MedicineDatabaseSql() : base()
        {
        }

        public MedicineDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Medicine> GetAll()
        {
            // Use Include method to connect object and its references from other tables
            return DbContext.Medicine
                .Include(m => m.MedicineManufacturer)
                .Include(m => m.MedicineType)
                .ToList();
        }

        public List<Medicine> GetApproved()
        {
            return GetAll().Where(m => m.IsApproved).ToList();
        }

        public List<Medicine> GetWaiting()
        {
            return GetAll().Where(m => !m.IsApproved).ToList();
        }

        public override Medicine GetById(string id)
        {
            return DbContext.Medicine.Find(id);
        }

        public override void Save(Medicine newEntity)
        {
            DbContext.Medicine.Add(newEntity);
            DbContext.SaveChanges();
        }

        public override void Update(Medicine updateEntity)
        {
            DbContext.Medicine.Update(updateEntity);
            DbContext.SaveChanges();
        }

        public override void Delete(string id)
        {
            var medicine = GetById(id);
            if (medicine == null) return;
            DbContext.Medicine.Remove(medicine);
            DbContext.SaveChanges();
        }

        public List<Medicine> GetByName(string name)
        {
            return GetAll().Where(m => m.CopyrightName.Equals(name) || m.CopyrightName.Equals(name)).ToList();
        }
    }
}