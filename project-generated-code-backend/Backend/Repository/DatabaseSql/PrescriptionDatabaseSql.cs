using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public PrescriptionDatabaseSql()
        {
        }

        public PrescriptionDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
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