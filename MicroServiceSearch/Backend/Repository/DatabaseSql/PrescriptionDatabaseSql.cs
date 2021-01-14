using System;
using System.Collections.Generic;
using System.Linq;
using MicroServiceSearch.Backend.Model;
using MicroServiceSearch.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceSearch.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericMsSearchDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public PrescriptionDatabaseSql()
        {
        }

        public PrescriptionDatabaseSql(MsSearchDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Prescription> GetAll()
        {
            return DbContext.Prescription
                .Include(p => p.MedicineDosage)
                .ToList();
        }

        public List<Prescription> GetPrescriptionsBetweenDates(DateTime[] datetimes)
        {
           var prescriptions= GetAll()
                .Where(t => t.Date > datetimes[0] && t.Date < datetimes[1])
                .ToList();
            foreach (var prescription in prescriptions)
                foreach (var medicineDosages in prescription.MedicineDosage)
                    DbContext.Medicine
                    .Where(m => m.SerialNumber == medicineDosages.MedicineSerialNumber)
                    .Include(m => m.MedicineType)
                    .ToList();
            return prescriptions;
        }
    }
}