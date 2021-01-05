using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public PrescriptionDatabaseSql(HealthCareSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Prescription> GetAll()
        {
            return DbContext.Prescription
                .Include(p => p.MedicineDosage)
                .ToList();
        }
    }
}