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
            return DbContext.Prescription
                .Where(t => t.Date > datetimes[0] && t.Date < datetimes[1])
                .Include(p => p.MedicineDosage)
                .ToList();
        }
    }
}