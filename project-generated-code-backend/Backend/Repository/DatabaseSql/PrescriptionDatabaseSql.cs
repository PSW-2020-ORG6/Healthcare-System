using System.Collections.Generic;
using System.Linq;
using HealthClinicBackend.Backend.Model.MedicalExam;
using HealthClinicBackend.Backend.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace HealthClinicBackend.Backend.Repository.DatabaseSql
{
    public class PrescriptionDatabaseSql : GenericDatabaseSql<Prescription>, IPrescriptionRepository
    {
        public PrescriptionDatabaseSql(HealthCareSystemDbContext context) : base(context)
        {
        }

        public override List<Prescription> GetAll()
        {
            return dbContext.Prescription
                .Include(p => p.MedicineDosage)
                .ToList();
        }
    }
}